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

    private void FixedUpdate()
    {
        _slimeStateMachine.Execute();
    }
}
