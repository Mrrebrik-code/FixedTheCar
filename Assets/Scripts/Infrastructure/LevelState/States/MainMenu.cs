using Infrastructure;
using Infrastructure.Configs;
using Plugins.DIContainer;
using Plugins.GameStateMachines.Interfaces;
using Plugins.Interfaces;

namespace Plugins.GameStateMachines.States
{
    public class MainMenu : IEnterState
    {
        [DI] private SceneLoader _sceneLoader;
        [DI] private Curtain _curtain;
        [DI] private ConfigLevelName _configLevel;
        
        public void Enter()
        {
            _sceneLoader.Load(_configLevel.MainMnu, _curtain.Unfade);
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}