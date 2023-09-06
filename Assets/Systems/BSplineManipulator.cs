using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BSplineObject))]
public class BSplineManipulator : MonoBehaviour {
    private event Action AddPointInputPressed;
    private BSpline BSpline => GetComponent<BSplineObject>().BSpline;
    private void AddPoint(Vector3 point) {
        Debug.Log("BSplineManipulator : AddPoint");
        float[] p = new float[] { point.x, point.y, point.z };
        BSpline.AddPoint(p);
        GetComponent<BSplineObject>().DispatchBSplineModified();
    }
    private void OnEnable() {
        AddPointInputPressed += OnInputAddPoint;
    }
    private void Update() => ListenInput();
    private void ListenInput() {
        if (Input.GetMouseButtonDown(0)) AddPointInputPressed?.Invoke();
    }
    private void OnInputAddPoint() {
        Debug.Log("BSplineManipulator : OnInputAddPoint");
        Vector3 mousePos = GetGroundMousePosition();
        if (mousePos == Vector3.zero) return;
        AddPoint(mousePos);
    }
    private Vector3 GetGroundMousePosition() {
        Debug.Log("BSplineManipulator : GetGroundMousePosition");
        Vector3 point = Vector3.zero;
        if (Camera.main == null) return point;
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance = 0;
        if (plane.Raycast(ray, out distance)) {
            point = ray.GetPoint(distance);
        }
        return point;
    }
}