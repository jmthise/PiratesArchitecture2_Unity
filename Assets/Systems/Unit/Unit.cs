using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Runtime.InteropServices;
using System.Reflection;

public class Unit : NetworkBehaviour {
    ICommandAuthoritySystem authority; // Checks if the sender has the right to send the command
    IHandler handler; // Gets the job from the command
    IProcessor processor; // Executes jobs
    public void ParseCommand(ICommand command, IControllerIdentity sender) {
        if (!authority.CheckCommand(command, sender)) return;
        IJob job = handler.GetJob(command);
        processor.Parse(job);
    }
}