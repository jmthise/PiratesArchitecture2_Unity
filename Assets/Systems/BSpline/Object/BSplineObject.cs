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
                _bSpline.OnModified += () => OnModified?.Invoke();
            }
        }
        public event Action OnModified;
    }
}