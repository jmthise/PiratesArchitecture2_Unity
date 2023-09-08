using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pirates.BSpline {
    public class BSplineObject : MonoBehaviour {
        private int degree = 2;
        private BSpline _bSpline;
        public BSpline BSpline {
            get {
                if (_bSpline == null) { _bSpline = new BSpline(degree); _bSpline.OnModified += () => OnModified?.Invoke(); }
                return _bSpline;
            }
            private set {
                _bSpline = value;
                _bSpline.OnModified += DispatchSplineModified;
            }
        }
        public event Action OnModified;
        public void DispatchSplineModified() => OnModified?.Invoke();
        public event Action<Vector3> OnMousePositionChanged;
        public void DispatchMousePositionChanged(Vector3 pos) => OnMousePositionChanged?.Invoke(pos);
    }
}