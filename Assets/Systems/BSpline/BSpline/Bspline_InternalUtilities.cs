using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pirates.BSpline {
    public partial class BSpline {
        int GetN() { if (points == null) return 0; return points.Count; }

        int GetKnotVectorLength() { return degree + n + 1; }

        int GetKnotIntervalLength() { return degree + n; }

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

        int[] GetDomain() {
            return new int[] { degree, knotVectorLength - 1 - degree };
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
    }
}