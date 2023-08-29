using System;
using System.Collections;

public interface IProcessor {
    void Execute(ControlCommand command, IControllable controllable);
}