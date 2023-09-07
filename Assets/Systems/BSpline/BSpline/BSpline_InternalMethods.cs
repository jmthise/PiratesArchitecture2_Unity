using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pirates.BSpline {
    public partial class BSpline {
        void UpdateKnots() {
            List<float> newKnots = new List<float>();
            switch (defaultKnotType) {
                case eKnotType.Uniform:
                    newKnots = GetUniformKnots();
                    break;
                case eKnotType.Clamped:
                    newKnots = GetClampedKnots();
                    break;
            }
            knots = newKnots;
        }

        int GetDimension() {
            if (points == null || points.Count == 0) return -1;
            return points[0].Length;
        }
    }
}