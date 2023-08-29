using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IControllable {
    private Unit_Controller _controller;
    public IController Controller {
        get {
            if (_controller == null) TryGetComponent<Unit_Controller>(out _controller);
            if (_controller == null) _controller = gameObject.AddComponent<Unit_Controller>();
            return _controller;
        }
    }

    private Unit_Handler _handler;
    public IHandler Handler {
        get {
            if (_handler == null) TryGetComponent<Unit_Handler>(out _handler);
            if (_handler == null) _handler = gameObject.AddComponent<Unit_Handler>();
            return _handler;
        }
    }

    private Unit_Notifier _notifier;
    public INotifier Notifier {
        get {
            if (_notifier == null) TryGetComponent<Unit_Notifier>(out _notifier);
            if (_notifier == null) _notifier = gameObject.AddComponent<Unit_Notifier>();
            return _notifier;
        }
    }
    private void Start() {
    }
}