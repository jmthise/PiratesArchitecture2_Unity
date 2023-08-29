using System;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class UnitComponent : MonoBehaviour
{
    private Unit _unit;
    public Unit Unit
    {
        get
        {
            if (_unit == null) TryGetComponent<Unit>(out _unit);
            if (_unit == null) _unit = gameObject.AddComponent<Unit>();
            return _unit;
        }
    }
}