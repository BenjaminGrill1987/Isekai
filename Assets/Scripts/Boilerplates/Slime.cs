using Isekai.Interface;
using Isekai.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    SlimeStateMachine _slimeStateMachine;

    public override void Start()
    {
        base.Start();
        _slimeStateMachine = new SlimeStateMachine(this);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        _slimeStateMachine.Execute();     
    }
}
