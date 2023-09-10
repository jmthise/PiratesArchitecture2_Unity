using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Runtime.InteropServices;
using System.Reflection;

public class Unit : NetworkBehaviour, IControllable {
    ICommandAuthorityChecker authority;
    public void ParseCommand(IUnitCommand command, ControllerIdentity sender) {
        if (!authority.HasCommandAuthority(command, sender)) return;
    }
}