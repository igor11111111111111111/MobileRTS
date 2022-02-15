public class StateMachine
{
    public State CurrentState { get; private set; }
    public State NextState { get; private set; }

    public void Initialize(State startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    public void ChangeState(State newState)
    {
        NextState = newState;

        CurrentState.Exit();

        CurrentState = newState;
        newState.Enter();
    }
}