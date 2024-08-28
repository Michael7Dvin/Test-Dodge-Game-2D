using _Codebase.Infrastructure.Services.SceneLoader;
using _Codebase.Infrastructure.StateMachine.States.Base;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.Device;

namespace _Codebase.Infrastructure.StateMachine.States
{
    public class InitializationState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public InitializationState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public async void Enter()
        {
            await Addressables.InitializeAsync();
            
            Application.targetFrameRate = 60;
            
            _gameStateMachine.EnterState<SceneLoadingState, SceneID>(SceneID.Forest);
        }
    }
}