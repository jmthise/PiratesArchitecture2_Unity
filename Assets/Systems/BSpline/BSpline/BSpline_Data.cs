using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Pirates.BSpline {
    public partial class BSpline {
        private List<float[]> _points = new List<float[]>();
        public List<float[]> points { get => _points; protected set => _points = value; }

        private List<float> _weights = new List<float>();
        public List<float> weights { get { return _weights; } protected set { _weights = value; } }

        private List<float> _knots = new List<float>();
        public List<float> knots { get { return _knots; } protected set { _knots = value; } }

        private int _degree = 3;
        public int degree { get { return Mathf.Min(Mathf.Max(1, n - 1), _degree); } protected set { _degree = value; UpdateKnots(); } }
        public int order { get { return degree + 1; } protected set => degree = value - 1; }

        public int dimension => GetDimension();

        public int[] domain => GetDomain();

        int knotIntervalLength => GetKnotIntervalLength();

        int knotVectorLength => GetKnotVectorLength();

        int n => GetN();

        public enum eKnotType {
            Uniform,
            Clamped
        }

        eKnotType defaultKnotType = eKnotType.Clamped;
    }
}