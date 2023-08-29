using System;
using UnityEngine;

public class Unit_Controller : UnitComponent, IController {
    public void TakeCommand(ControlCommand command) {
        command.Execute(Unit);
    }
}