using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SelectableComponent : MonoBehaviour {
    public virtual void SetSelected() { IsSelected = true; OnSelected?.Invoke(); }
    public virtual void SetDeselected() { IsSelected = false; OnDeselected?.Invoke(); }
    public event Action OnSelected;
    public event Action OnDeselected;
    public bool IsSelected { get; private set; }
}