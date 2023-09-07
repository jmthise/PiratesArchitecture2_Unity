using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;

namespace Pirates.BSpline {
    public partial class BSpline {
        public BSpline(int d, List<float[]> p = null) {
            degree = d;
            if (p != null) SetPoints(p);
        }
    }
}