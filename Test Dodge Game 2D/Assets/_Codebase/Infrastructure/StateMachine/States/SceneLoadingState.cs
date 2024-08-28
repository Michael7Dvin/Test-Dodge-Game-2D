using _Codebase.Infrastructure.Services.SceneLoader;
using _Codebase.Infrastructure.StateMachine.States.Base;

namespace _Codebase.Infrastructure.StateMachine.States
{
    public class SceneLoadingState : IStateWithArgument<SceneID>
    {
        private readonly ISceneLoader _sceneLoader;

        public SceneLoadingState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public async void Enter(SceneID sceneID) => 
            await _sceneLoader.Load(sceneID);
    }
}