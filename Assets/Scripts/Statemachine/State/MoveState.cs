using UnityEngine;

public class MoveState : BaseState
{
    Enemy _self;
    Vector2 _direction;

    public MoveState(Enemy self)
    {
        _self = self;
    }

    public override void OnEntry()
    {
    }

    public override void OnExecute()
    {
        Direction();
        Move();
    }

    private void Direction()
    {
        _direction = (_self.TargetToMove - (Vector2)_self.transform.position).normalized;
    }

    private void Move()
    {
        _self._rigidBody2D.velocity = _direction * _self.MoveSpeed;
    }

    public override void OnExit()
    {
        _self._rigidBody2D.velocity = Vector2.zero;
    }
}
