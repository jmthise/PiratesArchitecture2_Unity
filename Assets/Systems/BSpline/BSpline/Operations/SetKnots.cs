using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pirates.BSpline {
    public partial class BSpline {
        public class BSplineOperation_SetKnots : IBSplineOperation {
            private bool executed = false;
            private List<float> k;
            private List<float> prev_k;
            public BSplineOperation_SetKnots(List<float> k) {
                this.k = k;
            }
            public bool Execute(BSpline spline) {
                prev_k = new List<float>(spline.knots);
                if (k.Count != spline.knotVectorLength) {
                    Debug.LogWarning($"BSpline SetKnots : Operation not executed. Provided knot list did not match expected length. Knot list was of length {k.Count} and expected knot vector length of {spline.knotVectorLength}");
                    return false;
                }
                spline.knots = k;
                executed = true;
                spline.DispatchModified();
                return executed;
            }
            public bool Undo(BSpline spline) {
                spline.knots = prev_k;
                spline.DispatchModified();
                return true;
            }
        }
    }
}