using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Windows.Input;

<<<<<<< HEAD
public class Unit : NetworkBehaviour, IControllable
{
=======
public class Unit : NetworkBehaviour, IControllable, ISelectable {
>>>>>>> refs/remotes/origin/main
    public void RegisterCommand(ICommand command) { }
}