using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class Processor : MonoBehaviour {
    private Unit _unit;
    public Unit Unit {
        get { if (_unit == null) { _unit = GetComponent<Unit>(); } return _unit; }
    }
    private List<IProcess> stack;
    private List<IProcess> completed;
    public void Parse(IProcess action) { stack.Add(action); }
    private void Update() => ProcessStack();
    public virtual void ProcessStack() {
        if (stack == null || stack.Count <= 0) return;
        foreach (IProcess action in stack) {
            action.Execute(Unit);
            if (action.IsDone) {
                stack.Remove(action);
                completed.Add(action);
            }
        }
    }
}