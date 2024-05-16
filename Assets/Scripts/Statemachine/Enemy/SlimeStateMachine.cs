using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStateMachine : BaseStateMachine
{
    Enemy _self;
    IDLEState _iDLEState;
    MoveState _moveState;
    Vector2 _oldPosition;

    public SlimeStateMachine(Enemy self)
    {
        _self = self;
        _oldPosition = self.transform.position;
        _iDLEState = new IDLEState(self);
        _moveState = new MoveState(self);
        DefineTransition();
        ChangeState(_iDLEState);
    }

    protected override void DefineTransition()
    {
        _iDLEState.AddTransition(MoveTargetOutOfRange, _moveState);
        _moveState.AddTransition(IsTargetInRange, _iDLEState);
        _moveState.AddTransition(CantMove, _iDLEState);
    }

    private bool IsTargetInRange()
    {
        return Vector2.Distance((Vector2)_self.transform.position, _self.TargetToMove) <= _self.RangeToTarget;
    }

    private bool MoveTargetOutOfRange()
    {
        return Vector2.Distance((Vector2)_self.transform.position, _self.TargetToMove) > _self.RangeToTarget;
    }

    private bool CantMove()
    {        
        return _self._IsNotMoving;
    }
}
