using System;
using System.Collections.Generic;
using UnityEngine;
using Pirates.BSpline;

public class ShipHullGenerator {
    private float length = 0;
    private float width = 0;
    private float height = 0;
    private Mesh FrontSection;
    private Mesh MiddleSection;
    private Mesh RearSection;
    private Mesh hull;
    private BSpline CenterLine;

    private void BuildSplines() {
        BuildCenterSpline();
    }
    private void BuildCenterSpline() {
        CenterLine = new BSpline(3);
        Vector3 a = new Vector3(width * 0f, height * 1f, length * 0.5f);
        CenterLine.AddPoint(a);
        Vector3 b = new Vector3(width * 0f, height * 0f, length * 0.5f);
        CenterLine.AddPoint(b);
        Vector3 c = new Vector3(width * 0f, height * 0f, length * 0f);
        CenterLine.AddPoint(c);
        Vector3 d = new Vector3(width * 0f, height * 0f, length * -0.5f);
        CenterLine.AddPoint(d);
        Vector3 e = new Vector3(width * 0f, height * 1f, length * -0.5f);
        CenterLine.AddPoint(e);
    }
}