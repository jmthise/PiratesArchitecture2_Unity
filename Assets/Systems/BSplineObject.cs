using System;
using System.Collections.Generic;
using UnityEngine;

public class BSplineObject : MonoBehaviour {
    private int degree = 5;
    public event Action OnBSplineModified;
    private BSpline _bSpline;
    public BSpline BSpline {
        get {
            if (_bSpline == null) _bSpline = new BSpline(degree);
            return _bSpline;
        }
        private set {
            _bSpline = value;
        }
    }
    private void AddPoint(Vector3 point) {
        float[] p = new float[] { point.x, point.y, point.z };
        BSpline.AddPoint(p);
        BSpline.SetDegree(degree);
        OnBSplineModified?.Invoke();
    }
    private void Update() {
        if (Input.GetMouseButton(0)) {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance = 0;
            if (plane.Raycast(ray, out distance)) {
                AddPoint(ray.GetPoint(distance));
            }
        }
    }
}