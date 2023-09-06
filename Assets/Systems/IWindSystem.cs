using System;
using System.Collections.Generic;
using UnityEngine;

public interface IWindSystem
{
    Vector3 GetWindAtPoint(Vector3 wind);
}