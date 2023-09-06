using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BSplineObject))]
public class BSplineRenderer : MonoBehaviour {
    [SerializeField] bool render = true;
    [SerializeField] int resolution = 100;
    private BSpline BSpline => GetComponent<BSplineObject>().BSpline;
    List<Vector3> eval;
    private void OnEnable() {
        GetComponent<BSplineObject>().OnModified += RebuildEval;
    }
    private void Update() {
        if (render) DrawBSpline();
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