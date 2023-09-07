using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Pirates.BSpline {
    public partial class BSpline {
        public class BSplineOperation_AddPoint : IBSplineOperation {
            private bool executed = false;
            private float[] p;
            private float w;
            private List<float[]> prev_p;
            private List<float> prev_w;
            public BSplineOperation_AddPoint(float[] p, float w = 1) {
                this.p = p;
                this.w = w;
            }
            public bool Execute(BSpline spline) {
                if (spline.dimension != -1 && p.Length != spline.dimension) {
                    Debug.LogWarning($"BSpline AddPoint : Operation not executed. Point [{p}] not matching BSpline dimension [{spline.dimension}]");
                    return false;
                }

                prev_p = new List<float[]>(spline.points.Select(p => p.ToArray()).ToList());
                prev_w = new List<float>(spline.weights);

                spline.points.Add(p);
                w = Mathf.Clamp01(w);
                spline.weights.Add(w);
                spline.UpdateKnots();
                spline.DispatchModified();
                executed = true;
                return executed;
            }
            public bool Undo(BSpline spline) {
                Debug.Log($"BSpline AddPoint : Undo");
                spline.points = prev_p;
                spline.weights = prev_w;
                spline.UpdateKnots();
                spline.DispatchModified();
                return true;
            }
        }
    }
}