using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Pirates.BSpline {
    public class BSpline {
        public BSpline(int d, List<float[]> p = null) {
            points = new List<float[]>();
            weights = new List<float>();
            knots = new List<float>();
            SetDegree(d);
            if (p != null) SetPoints(p);
        }

        int n => GetN();
        int GetN() {
            if (points == null) return 0;
            return points.Count;
        }

        #region POINTS

        private List<float[]> _points;
        public List<float[]> points { get => _points; private set => _points = value; }

        public void AddPoint(float[] p, float w = 1) {
            if (p == null) return;
            if (points.Count > 0 && p.Length != dimension) { Debug.LogWarning($"Point [{p}] not matching Dimension [{dimension}]"); return; }
            if (points.Count == 0) SetDimension(p.Length);
            points.Add(p);
            AddWeight(w);
            UpdateKnots();
        }

        void SetPoint(int i, float[] p, float w = 1) {
            if (p == null) return;
            if (i >= points.Count) return;
            if (p.Length != dimension) { Debug.LogWarning($"Point [{p}] not matching Dimension [{dimension}]"); return; }
            points[i] = p;
            SetWeight(i, w);
        }

        void SetPoints(List<float[]> p) {
            if (p == null) return;
            points = new List<float[]>();
            for (int i = 0; i < p.Count; i++) {
                AddPoint(p[i]);
            }
        }

        #endregion}

        #region WEIGHTS

        private List<float> _weights;
        public List<float> weights { get { return _weights; } protected set { _weights = value; } }

        void AddWeight(float w) {
            w = Mathf.Clamp01(w);
            weights.Add(w);
        }

        void SetWeight(int i, float w) {
            if (i >= n) return;
            w = Mathf.Clamp01(w);
            weights[i] = w;
        }

        #endregion

        #region KNOTS

        private List<float> _knots;
        public List<float> knots { get { return _knots; } protected set { _knots = value; } }

        int knotVectorLength => CalculateKnotVectorLength();
        int knotIntervalLength => CalculateKnotIntervalLength();
        int CalculateKnotVectorLength() => degree + n + 1;
        int CalculateKnotIntervalLength() => degree + n;

        void SetKnotsToClamped() => knots = GetClampedKnots();
        void SetKnotsToUniform() => knots = GetUniformKnots();
        void UpdateKnots() => SetKnotsToClamped();

        void SetKnots(List<float> k) {
            if (k == null || k.Count != knotVectorLength) UpdateKnots();
            knots = new List<float>();
            for (int i = 0; i < knotVectorLength; i++) {
                knots[i] = k[i];
            }
        }

        List<float> GetClampedKnots() {
            List<float> k = new List<float>();
            for (int i = 0; i < knotVectorLength; i++) {
                int knotValue = i;
                if (i <= domain[0]) knotValue = domain[0];
                if (i >= domain[1]) knotValue = domain[1];
                k.Add(knotValue);
            }
            return k;
        }

        List<float> GetUniformKnots() {
            List<float> k = new List<float>();
            for (int i = 0; i < knotVectorLength; i++) {
                int knotValue = i;
                k.Add(i);
            }
            return k;
        }

        #endregion

        #region DEGREE

        private int _degree;
        public int degree { get => GetDegree(); protected set => SetDegree(value); }
        public int order { get => degree + 1; protected set => degree = value - 1; }

        int GetDegree() { return Mathf.Min(Mathf.Max(1, n - 1), _degree); }
        public void SetDegree(int d) { _degree = d; UpdateKnots(); }

        #endregion

        #region DOMAIN

        public int[] domain => GetDomain();
        int[] GetDomain() => new int[] { degree, knotVectorLength - 1 - degree };

        #endregion

        #region DIMENSION

        private int _dimension;
        public int dimension { get => _dimension; protected set => _dimension = value; }
        void SetDimension(int d) => dimension = d;

        #endregion

        #region UTILITIES

        public int GetSegment(float t) {
            t = RemapTimeToDomain(t);

            int s;
            for (s = domain[0]; s < domain[1]; s++) {
                if (t >= knots[s] && t <= knots[s + 1]) break;
            }
            return s;
        }

        float RemapTimeToDomain(float t) {
            float high = knots[domain[0]];
            float low = knots[domain[1]];
            float result = t * (high - low) + low;
            return result;
        }

        List<float[]> ConvertCartesianToHomogenousCoordinates(List<float[]> p, List<float> w) {
            List<float[]> homogenous = new List<float[]>();
            for (int i = 0; i < p.Count; i++) {
                homogenous.Add(new float[dimension + 1]);
                for (int j = 0; j < dimension; j++) {
                    homogenous[i][j] = p[i][j] * w[i];
                }
                homogenous[i][dimension] = w[i];
            }
            return homogenous;
        }

        List<float[]> ConvertHomogenousToCartesianCoordinates(List<float[]> p) {
            List<float[]> cartesian = new List<float[]>();
            int dim = Mathf.Max(0, p[0].Length - 1);
            for (int i = 0; i < p.Count; i++) {
                cartesian.Add(new float[dim]);
                for (int j = 0; j < dim; j++) {
                    cartesian[i][j] = p[i][j] / p[i][dim];
                }
            }
            return cartesian;
        }

        public float[] GetPointOnCurveAtTime(float t) {
            if (points == null || points.Count < 2) return new float[] { 0, 0, 0 };

            float scalar = RemapTimeToDomain(t);
            int segment = GetSegment(t);

            List<float[]> v = ConvertCartesianToHomogenousCoordinates(points, weights);

            float alpha;
            for (int l = 1; l < degree + 1; l++) {
                for (int i = segment; i > segment - degree - 1 + l; i--) {
                    alpha = (scalar - knots[i]) / (knots[i + degree + 1 - l] - knots[i]);
                    for (int j = 0; j < dimension + 1; j++) {
                        // Debug.Log($"n = [{n}], i = [{i}], j = [{j}], scalar = [{scalar}], knotVectorLength = [{knotVectorLength}], knots.Count = [{knots.Count}], degree = [{degree}]");
                        v[i][j] = (1 - alpha) * v[i - 1][j] + alpha * v[i][j];
                    }
                }
            }

            float[] result = new float[dimension];
            for (int i = 0; i < dimension; i++) {
                result[i] = v[segment][i] / v[segment][dimension];
            }

            return result;
        }

        #endregion

    }
}
