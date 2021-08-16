using Infrastructure.Configs;
using Plugins.DIContainer;
using Plugins.GameStateMachines.Interfaces;
using Plugins.Interfaces;

namespace Infrastructure.LevelState.SceneScripts.Garages
{
    public class GameScene : IPayLoadedState<ConfigLevel>
    {
        [DI] private Curtain _curtain;
        [DI] private SceneLoader _sceneLoader;
        [DI] private ConfigLevelName _levelName;
        
        public void Enter(ConfigLevel payLoaded) => _sceneLoader.Load(_levelName.GameLevel, ()=>_curtain.Unfade());

        public void Exit()
        {
            
        }
    }
}