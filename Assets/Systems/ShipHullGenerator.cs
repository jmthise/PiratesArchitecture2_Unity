using System;
using System.Collections.Generic;
using UnityEngine;
using Pirates.BSpline;

public class ShipHullGenerator {
    private float length;
    private float width;
    private Mesh FrontSection;
    private Mesh MiddleSection;
    private Mesh RearSection;
    private Mesh hull;
    private BSpline CenterLine;
}