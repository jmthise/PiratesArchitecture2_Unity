using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pirates.BSpline {
    public partial class BSpline {
        public class BSplineOperation_SetKnotsToUniform : IBSplineOperation {
            private bool executed = false;
            private List<float> prev_k;
            private eKnotType prev_knotType;
            public BSplineOperation_SetKnotsToUniform() {
            }
            public bool Execute(BSpline spline) {
                prev_k = new List<float>(spline.knots);
                prev_knotType = spline.defaultKnotType;

                spline.defaultKnotType = eKnotType.Uniform;
                spline.UpdateKnots();
                executed = true;
                spline.DispatchModified();
                return executed;
            }
            public bool Undo(BSpline spline) {
                spline.defaultKnotType = prev_knotType;
                spline.knots = prev_k;
                spline.UpdateKnots();
                spline.DispatchModified();
                return true;
            }
        }
    }
}