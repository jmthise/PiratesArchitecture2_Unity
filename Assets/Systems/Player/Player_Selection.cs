using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Selection {
    private List<ISelectable> _selected;
    public List<ISelectable> selected { get; private set; }
    public bool Select(List<ISelectable> selectables, bool additive) {
        if (!additive) ClearSelection();
        foreach (ISelectable selectable in selectables) {
            Select(selectable, false);
        }
        return true;
    }
    public bool Select(ISelectable selectable, bool additive) {
        if (!additive) ClearSelection();
        if (selected.Contains(selectable)) return false;
        selected.Add(selectable);
        selectable.SetSelected();
        return true;
    }
    public bool Deselect(List<ISelectable> selectables) {
        foreach (ISelectable selectable in selectables) {
            Deselect(selectable);
        }
        return true;
    }
    public bool Deselect(ISelectable selectable) {
        if (!selected.Contains(selectable)) return false;
        selected.Remove(selectable);
        selectable.SetDeselected();
        return true;
    }
    public void ClearSelection() {
        do {
            Deselect(selected[0]);
        } while (selected.Count > 0);
    }
}