using System;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable {
    SelectableComponent selectionComponent { get; }
}