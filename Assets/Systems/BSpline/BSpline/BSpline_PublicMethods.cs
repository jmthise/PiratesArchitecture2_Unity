using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pirates.BSpline {
    public partial class BSpline {
        public void AddPoint(float[] p, float w = 1) {
            var op = new BSplineOperation_AddPoint(p, w);
            Operate(op);
        }
        public void AddPoints(List<float[]> p, List<float> w) {
            var op = new BSplineOperation_AddPoints(p, w);
            Operate(op);
        }
        public void SetPoint(int i, float[] p, float w = 1) {
            var op = new BSplineOperation_SetPoint(i, p, w);
            Operate(op);
        }
        public void SetPoints(List<float[]> p) {
            var op = new BSplineOperation_SetPoints(p);
            Operate(op);
        }
        public void SetWeight(int i, float w) {
            var op = new BSplineOperation_SetWeight(i, w);
            Operate(op);
        }
        public void SetKnotsToClamped() {
            var op = new BSplineOperation_SetKnotsToClamped();
            Operate(op);
        }
        public void SetKnotsToUniform() {
            var op = new BSplineOperation_SetKnotsToUniform();
            Operate(op);
        }
        public void SetKnots(List<float> k) {
            var op = new BSplineOperation_SetKnots(k);
            Operate(op);
        }
        public void SetDegree(int d) {
            var op = new BSplineOperation_SetDegree(d);
            Operate(op);
        }
    }
}