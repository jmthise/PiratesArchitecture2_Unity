using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pirates.BSpline {
    public partial class BSpline {
        public class BSplineOperation_SetWeight : IBSplineOperation {
            private bool executed = false;
            private int i;
            private float w;
            private float prev_w;
            public BSplineOperation_SetWeight(int i, float w) {
                this.i = i;
                this.w = w;
            }
            public bool Execute(BSpline spline) {
                prev_w = spline.weights[i];

                if (i >= spline.n) { return false; }
                w = Mathf.Clamp01(w);
                spline.weights[i] = w;
                executed = true;
                spline.DispatchModified();
                return executed;
            }
            public bool Undo(BSpline spline) {
                spline.weights[i] = prev_w;
                spline.DispatchModified();
                return true;
            }
        }
    }
}