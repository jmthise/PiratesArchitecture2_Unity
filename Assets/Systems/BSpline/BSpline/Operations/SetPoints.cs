using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Pirates.BSpline {
    public partial class BSpline {
        public class BSplineOperation_SetPoints : IBSplineOperation {
            private bool executed = false;
            private List<float[]> p;
            private List<float> w;
            private List<float[]> prev_p;
            private List<float> prev_w;
            public BSplineOperation_SetPoints(List<float[]> p, List<float> w = null) {
                this.p = p;
                this.w = w;
            }
            public bool Execute(BSpline spline) {
                prev_p = new List<float[]>(spline.points.Select(p => p.ToArray()).ToList());
                prev_w = new List<float>(spline.weights);

                foreach (var point in p) {
                    if (spline.dimension != -1 && point.Length != spline.dimension) {
                        Debug.LogWarning($"BSpline SetPoints : Operation not executed. Point [{point}] not matching BSpline dimension [{spline.dimension}]");
                        return false;
                    }
                }
                spline.points = p;
                if (w == null || w.Count != p.Count) { w = new List<float>(); for (int i = 0; i < p.Count; i++) { w.Add(1); } }
                spline.weights = w;
                spline.UpdateKnots();
                executed = true;
                spline.DispatchModified();
                return executed;
            }
            public bool Undo(BSpline spline) {
                spline.points = prev_p;
                spline.weights = prev_w;
                spline.UpdateKnots();
                spline.DispatchModified();
                return true;
            }
        }
    }
}