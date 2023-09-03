using UnityEngine;
using UnityEngine.UIElements;
using System;
using System.Collections.Generic;

public class MainWindow : MonoBehaviour {
    [SerializeField] private UIDocument _document;
    [SerializeField] private StyleSheet _styleSheet;
    private void Start() { Generate(); }
    private void Generate() {
        var root = _document.rootVisualElement;
        root.styleSheets.Add(_styleSheet);

        VisualElement networkMenu = new NetworkMenu();
        root.Add(networkMenu);
    }
}