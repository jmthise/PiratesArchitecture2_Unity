using System;
using System.Collections.Generic;
using UnityEngine;

public class Unit_CommandHandler : MonoBehaviour, ICommandHandler {
    public IProcess GetAction(Command command) {
        IProcess action = null;
        return action;
    }
}