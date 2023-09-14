using System;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPosition : IProcess {
    public bool IsDone { get; private set; }
    float minDist = 0.1f;
    float moveSpeed = 1f;
    Command_MoveToPosition command;
    public MoveToPosition(Command_MoveToPosition command) {
        this.command = command;
    }
    public void Execute(Unit unit) {
        float distFromTarget = Vector3.Distance(unit.transform.position, command.position);
        if (distFromTarget <= minDist) { IsDone = true; return; }
        Vector3 dir = command.position - unit.transform.position;
        unit.transform.position += dir.normalized * Time.deltaTime;
        unit.transform.rotation = Quaternion.RotateTowards(unit.transform.rotation, Quaternion.LookRotation(dir), 360f * Time.deltaTime);
    }
}