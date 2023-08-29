using System;
using UnityEngine;

public class UnitCommand_MoveInDirection : ControlCommand {
    private Vector3 _direction;
    public Vector3 Direction { get => _direction; private set { _direction = value; } }
    public UnitCommand_MoveInDirection(Vector3 direction) {
        Direction = direction;
    }
}