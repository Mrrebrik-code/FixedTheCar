using System.Collections.Generic;
using Plugins.DIContainer;
using Plugins.GameStateMachines.Interfaces;
using Plugins.Interfaces;

namespace Plugins.GameStateMachines.States
{
    public class InitGame : IEnterState
    {
        private DiBox _diBox = DiBox.MainBox;

        [DI] private LevelStateMachine _levelStateMachine;
        [DI] private Curtain _curtain;

        public void Enter()
        {
            CreateDi();
            _curtain.Fade(()=>_levelStateMachine.Enter<MainMenu>());
        }

        public void Exit()
        {
            
        }
        
        private void CreateDi()
        {
            
        }
    }
}