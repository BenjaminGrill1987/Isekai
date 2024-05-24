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
