namespace _Codebase.Infrastructure.StateMachine.States.Base
{
    public interface IState : IExitableState
    { 
        void Enter();
    }
}