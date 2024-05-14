using UnityEngine;

public class IDLEState : BaseState
{
    Enemy _self;

    public IDLEState(Enemy newSelf)
    {
        _self = newSelf;
    }

    public override void OnEntry()
    {

    }

    public override void OnExecute()
    {
        _self.SetTargetToMove(_self.MoveCircleMiddlePoint + Random.insideUnitCircle * _self.CircleRange);
    }

    public override void OnExit()
    {

    }
}
