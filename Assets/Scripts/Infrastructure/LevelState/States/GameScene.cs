using Infrastructure.Configs;
using Plugins.DIContainer;
using Plugins.GameStateMachines.Interfaces;
using Plugins.Interfaces;

namespace Infrastructure.LevelState.States
{
    public class GameScene : IPayLoadedState<ConfigLevel>
    {
        [DI] private SceneLoader _sceneLoader;
        [DI] private ConfigLevelName _levelName;
        
        private DiBox _diBox = DiBox.MainBox;
        
        public void Enter(ConfigLevel payLoaded)
        {
            _diBox.RegisterSingle(payLoaded);
            _sceneLoader.Load(_levelName.GameLevel);
        }

        public void Exit()
        {
            _diBox.RemoveSingel<ConfigLevel>();
        }
    }
}