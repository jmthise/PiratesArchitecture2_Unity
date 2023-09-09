using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pirates.BSpline {
    public partial class BSpline {
        public void AddPoint(Vector3 point) {
            float[] p = new float[] { point.x, point.y, point.z };
            AddPoint(p);
        }
        public void AddPoint(Vector2 point) {
            float[] p = new float[] { point.x, point.y };
            AddPoint(p);
        }
    }
}