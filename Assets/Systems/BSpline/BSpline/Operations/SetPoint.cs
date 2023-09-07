using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pirates.BSpline {
    public partial class BSpline {
        public class BSplineOperation_SetPoint : IBSplineOperation {
            private bool executed = false;
            private int i;
            private float[] p;
            private float[] prev_p;
            private float w;
            private float prev_w;
            public BSplineOperation_SetPoint(int i, float[] p, float w = 1) {
                this.i = i;
                this.p = p;
                this.w = w;
            }
            public bool Execute(BSpline spline) {
                prev_p = (float[])p.Clone();
                prev_w = spline.weights[i];

                if (i >= spline.points.Count) return false;
                if (p.Length != spline.dimension) {
                    Debug.LogWarning($"BSpline SetPoint : Operation not executed. Point [{p}] not matching Dimension [{spline.dimension}]");
                    return false;
                }
                spline.points[i] = p;
                spline.weights[i] = w;
                executed = true;
                spline.DispatchModified();
                return executed;
            }
            public bool Undo(BSpline spline) {
                spline.points[i] = prev_p;
                spline.weights[i] = prev_w;
                spline.DispatchModified();
                return true;
            }
        }
    }
}