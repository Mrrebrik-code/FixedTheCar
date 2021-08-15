using Infrastructure.Configs;
using Plugins.DIContainer;
using Plugins.GameStateMachines.Interfaces;
using Plugins.Interfaces;

namespace Infrastructure.LevelState.States
{
    public class Garage : IEnterState
    {
        [DI] private SceneLoader _sceneLoader;
        [DI] private ConfigLevelName _configLevel;
        [DI] private Curtain _curtain;
        
        public void Enter()
        {
            _sceneLoader.Load(_configLevel.Garage, ()=>_curtain.Unfade());
        }

        public void Exit()
        {
        }
    }
}