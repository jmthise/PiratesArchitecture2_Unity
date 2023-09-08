using System;
using System.Collections.Generic;
using UnityEngine;

// Public utilities
namespace Pirates.BSpline {
    public partial class BSpline {
        public int GetSegment(float t) {
            t = RemapTimeToDomain(t);
            int s;
            for (s = domain[0]; s < domain[1]; s++) {
                if (t >= knots[s] && t <= knots[s + 1]) break;
            }
            return s;
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

        // Calculate Euclidean distance between two points in n-dimensional space.
        private float Distance(float[] a, float[] b) {
            if (a.Length != b.Length) return -1;

            float sum = 0;
            for (int i = 0; i < a.Length; i++) {
                sum += (a[i] - b[i]) * (a[i] - b[i]);
            }
            return Mathf.Sqrt(sum);
        }

        // Find the index of the closest control point to a given position array.
        public int GetClosestControlPointIndex(float[] position) {
            if (position.Length != dimension) {
                return -1;
            }

            int closestIndex = -1;
            float closestDistance = float.MaxValue;

            for (int i = 0; i < points.Count; i++) {
                float currentDistance = Distance(position, points[i]);
                if (currentDistance < closestDistance) {
                    closestDistance = currentDistance;
                    closestIndex = i;
                }
            }

            return closestIndex;
        }
    }
}