using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCommand {
    public void Execute(IControllable controllable) => controllable.Handler.Handle(this);
}