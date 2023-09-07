using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pirates.BSpline {
    public partial class BSpline {
        public interface IBSplineOperation {
            bool Execute(BSpline spline);
            bool Undo(BSpline spline);
        }
    }
}