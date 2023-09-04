public class BaseState
{
    private string stateName;
    private StateMachine stateMachine;

    public string StateName { get => stateName; set => stateName = value; }

    public BaseState(string stateName, StateMachine stateMachine)
    {
        this.stateName = stateName;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void UpdateState() { }

}
