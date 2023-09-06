using System;
using System.Collections.Generic;
using UnityEngine;

public class BSplineObject : MonoBehaviour {
    private int degree = 5;
    private BSpline _bSpline;
    public BSpline BSpline {
        get {
            if (_bSpline == null) { _bSpline = new BSpline(degree); }
            return _bSpline;
        }
        private set {
            _bSpline = value;
        }
    }
    public event Action OnModified;
    public void DispatchBSplineModified() { Debug.Log("BSplineObject OnModified"); OnModified?.Invoke(); }
}