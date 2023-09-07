using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pirates.BSpline {
    public partial class BSpline {
        public class BSplineOperation_SetDegree : IBSplineOperation {
            private bool executed = false;
            private int d;
            private int prev_d;
            public BSplineOperation_SetDegree(int d) {
                this.d = d;
            }
            public bool Execute(BSpline spline) {
                prev_d = spline.degree;
                spline.degree = d;
                executed = true;
                spline.DispatchModified();
                return executed;
            }
            public bool Undo(BSpline spline) {
                spline.degree = prev_d;
                spline.DispatchModified();
                return true;
            }
        }
    }
}