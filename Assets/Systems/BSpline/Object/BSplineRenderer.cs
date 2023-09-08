using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Pirates.BSpline {
    [RequireComponent(typeof(BSplineObject))]
    public class BSplineRenderer : MonoBehaviour {
        [SerializeField] bool render = true;
        [SerializeField] int resolution = 100;
        private BSpline BSpline => GetComponent<BSplineObject>().BSpline;
        List<Vector3> eval;
        private void OnEnable() {
            BSplineObject bso = GetComponent<BSplineObject>();
            bso.OnModified += RebuildEval;
            bso.OnMousePositionChanged += DrawClosestPoint;
        }
        private void Update() {
            if (!render) return;
            DrawBSpline();
            DrawPoints();
        }
        private void DrawPoints() {
            for (int i = 0; i < BSpline.points.Count; i++) {
                float[] point = BSpline.points[i];
                Vector3 pos;
                if (point.Length == 2) pos = new Vector3(point[0], 0, point[1]);
                else if (point.Length == 3) pos = new Vector3(point[0], point[1], point[2]);
                else continue;
                Debug.DrawRay(pos, Vector3.up * 0.25f, Color.blue, Time.deltaTime);
            }
        }
        private void DrawClosestPoint(Vector3 pos) {
            float[] mousePos;
            if (BSpline.dimension == 2) mousePos = new float[] { pos.x, pos.y };
            else if (BSpline.dimension == 3) mousePos = new float[] { pos.x, pos.y, pos.z };
            else return;
            int index = BSpline.GetClosestControlPointIndex(mousePos);
            float[] point = BSpline.points[index];
            if (point.Length == 2) pos = new Vector3(point[0], 0, point[1]);
            else if (point.Length == 3) pos = new Vector3(point[0], point[1], point[2]);
            else return;
            Debug.DrawLine(pos, pos + Vector3.up * 0.5f, Color.green, Time.deltaTime);
        }
        private void RebuildEval() {
            Debug.Log("BSplineRenderer : Rebuilding Evaluation");
            eval = new List<Vector3>();
            for (int i = 0; i <= resolution; i++) {
                float step = 1f / resolution;
                float t = step * i;
                float[] p = BSpline.GetPointOnCurveAtTime(t);
                Vector3 point = new Vector3(p[0], p[1], p[2]);
                eval.Add(point);
            }
        }
        private void DrawBSpline() {
            Debug.Log("BSplineRenderer : Drawing BSpline");
            if (eval == null || eval.Count < 2) return;
            for (int i = 0; i < eval.Count - 1; i++) {
                Debug.DrawLine(eval[i], eval[i + 1], Color.black, Time.deltaTime);
                Debug.DrawRay(eval[i], Vector3.up * 0.1f, Color.red, Time.deltaTime);
            }
        }
    }
}