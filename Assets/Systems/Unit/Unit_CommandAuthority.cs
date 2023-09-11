using System;
using System.Collections.Generic;
using UnityEngine;

public class Unit_CommandAuthority : MonoBehaviour, ICommandAuthoritySystem {
    public bool HasCommandAuthority(Command command, ControllerIdentity identity) { return true; }
}