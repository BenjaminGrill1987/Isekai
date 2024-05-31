using Isekai.Input;
using Isekai.Utility;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private Controlls _input;

    public static Controlls Input => _Instance._input;

    public override void Awake()
    {
        base.Awake();
        _input = new Controlls();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}
