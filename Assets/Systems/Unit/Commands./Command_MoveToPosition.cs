using System;
using System.Collections.Generic;
using UnityEngine;

public class Command_MoveToPosition : Command {
    public Vector3 position;
    public Command_MoveToPosition(Vector3 position) {
        this.position = position;
    }
}