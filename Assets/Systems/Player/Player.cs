using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Player : NetworkBehaviour, IController {
    public Player_Selection Selection { get; private set; }
    public ControllerIdentity identity { get; private set; }
}