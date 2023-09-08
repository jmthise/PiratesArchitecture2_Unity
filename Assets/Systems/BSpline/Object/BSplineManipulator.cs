using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pirates.BSpline {
    [RequireComponent(typeof(BSplineObject))]
    public class BSplineManipulator : MonoBehaviour {
        private event Action OnInputAddPoint;
        private event Action OnInputUndo;
        private event Action OnInputRedo;
        private BSpline BSpline => GetComponent<BSplineObject>().BSpline;
        private void AddPoint(Vector3 point) {
            Debug.Log("BSplineManipulator : AddPoint");
            float[] p = new float[] { point.x, point.y, point.z };
            BSpline.AddPoint(p);
        }
        private void OnEnable() {
            OnInputAddPoint += AddPoint;
            OnInputUndo += Undo;
            OnInputRedo += Redo;
        }
        private void Update() {
            ListenInput();
            BroadcastMousePosition();
        }
        private void ListenInput() {
            if (Input.GetMouseButtonDown(0)) OnInputAddPoint?.Invoke();
            if (Input.GetKeyDown(KeyCode.Z)) OnInputUndo?.Invoke();
            if (Input.GetKeyDown(KeyCode.Y)) OnInputRedo?.Invoke();
        }
        private void AddPoint() {
            Debug.Log("BSplineManipulator : OnInputAddPoint");
            Vector3 mousePos = GetGroundMousePosition();
            if (mousePos == Vector3.zero) return;
            AddPoint(mousePos);
        }
        private void BroadcastMousePosition() {
            Vector3 mousePos = GetGroundMousePosition();
            if (mousePos == Vector3.zero) return;
            GetComponent<BSplineObject>().DispatchMousePositionChanged(mousePos);
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
        private void Undo() { BSpline.UndoOperation(); }
        private void Redo() { BSpline.RedoOperation(); }
    }
}