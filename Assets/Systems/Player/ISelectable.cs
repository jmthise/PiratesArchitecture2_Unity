using System;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable {
    bool Selected { get; }
    void SetSelected();
    void SetDeselected();
}