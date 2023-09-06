using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BSplineObject))]
public class BSplineRenderer : MonoBehaviour {
    [SerializeField] int resolution = 100;
    private BSpline BSpline => GetComponent<BSplineObject>().BSpline;
    List<Vector3> eval;
    private void OnEnable() {
        BSplineObject bSplineObject = GetComponent<BSplineObject>();
        bSplineObject.OnBSplineModified += RebuildEval;
    }
    private void Update() {
        DrawBSpline();
    }
    private void RebuildEval() {
        eval = new List<Vector3>();
        for (int i = 0; i < resolution; i++) {
            float timeFrom = (float)i / (float)resolution;
            float timeTo = ((float)i + 1f) / (float)resolution;
            float[] point = BSpline.GetPointOnCurveAtTime(timeFrom);
            if (point.Length != 3) return;
            Vector3 p = new Vector3(point[0], point[1], point[2]);
            eval.Add(p);
        }
    }
    private void DrawBSpline() {
        if (eval == null || eval.Count < 2) return;
        for (int i = 0; i < eval.Count - 1; i++) {
            Debug.DrawLine(eval[i], eval[i + 1], Color.black, Time.deltaTime);
            Debug.DrawRay(eval[i], Vector3.up * 0.1f, Color.red, Time.deltaTime);
        }
    }
}