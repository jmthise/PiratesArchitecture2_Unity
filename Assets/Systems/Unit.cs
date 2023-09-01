using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Windows.Input;

public class Unit : NetworkBehaviour, IControllable {
    public void RegisterCommand(ICommand command) { }
}