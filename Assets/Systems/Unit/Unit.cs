using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Runtime.InteropServices;
using System.Reflection;
using UnityEngine.UI;

[RequireComponent(typeof(Unit_CommandAuthority))]
[RequireComponent(typeof(Unit_CommandHandler))]
[RequireComponent(typeof(Processor))]
public class Unit : NetworkBehaviour, IControllable, ISelectable {
    public SelectableComponent selectionComponent => GetComponent<SelectableComponent>();
    ICommandAuthoritySystem authority => GetComponent<Unit_CommandAuthority>(); // Checks if the command can be sent by the controller based on it's identity
    ICommandHandler handler => GetComponent<Unit_CommandHandler>(); // Factory that maps a command into a process
    Processor processor => GetComponent<Processor>(); // Responsible for processing processes
    public void ParseCommand(Command command, ControllerIdentity sender) {
        if (!authority.HasCommandAuthority(command, sender)) return;
        IProcess process = handler.GetAction(command);
        if (process != null) processor.Parse(process);
    }
}