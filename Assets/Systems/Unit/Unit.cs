using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Runtime.InteropServices;
using System.Reflection;

[RequireComponent(typeof(Unit_CommandAuthority))]
public class Unit : NetworkBehaviour, IControllable, ISelectable {
    ICommandAuthoritySystem authority => GetComponent<Unit_CommandAuthority>(); // Checks if the command can be sent by the controller based on it's identity
    ICommandHandler handler => GetComponent<Unit_CommandHandler>(); // Factory that maps a command into a process
    Processor processor => GetComponent<Processor>(); // Responsible for processing processes
    public void ParseCommand(Command command, ControllerIdentity sender) {
        if (!authority.HasCommandAuthority(command, sender)) return;
        IProcess process = handler.GetAction(command);
        if (process != null) processor.Parse(process);
    }
    private bool _selected;
    public bool Selected { get { return _selected; } private set { _selected = value; } }
    public void SetSelected() { Selected = true; }
    public void SetDeselected() { Selected = false; }
}