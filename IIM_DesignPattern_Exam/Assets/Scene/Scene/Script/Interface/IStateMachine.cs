
public interface IStateMachine
{
    IState EntryPoint { get; }
    IState CurrentState { get; }
    void ResetMachineState();
    void ChangeState(IState s);
    void UpdateState();
}
