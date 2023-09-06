using System;
using System.Collections.Generic;
using UnityEngine;

public interface IOceanSystem {
    Vector3 GetWaterHeightAtPoint(Vector3 point);
    Vector3 GetWaterHeightAtPoints(Vector3[] point);
}