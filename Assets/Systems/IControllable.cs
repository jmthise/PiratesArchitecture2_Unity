using System;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

public interface IControllable {
    void RegisterCommand(ICommand command);
}