using System;
using UnityEngine;

public class HandlerMouse {
    private Controls _controls;
    private float _differenceTime;
    public event Action<float> UpButtonEvent;
    public event Action<Vector2> MoveMouseEvent;
    public void Initialize() {
        _controls = new Controls();
        _controls.MouseControl.Enable();
        _controls.MouseControl.ButtonLeft.started += context => { OnDownButton(); };
        _controls.MouseControl.ButtonLeft.canceled += context => { OnUpButton(); };
        _controls.MouseControl.MoveMouse.performed += context => { MoveMouseEvent?.Invoke(context.ReadValue<Vector2>()); }; ;
    }
    private void OnDownButton() { _differenceTime = Time.time; }
    private void OnUpButton() {
        _differenceTime = Time.time - _differenceTime;
        UpButtonEvent?.Invoke(_differenceTime);
    }
}