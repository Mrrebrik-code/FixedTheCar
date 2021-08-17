using System;
using System.Collections;
using Plugins.DIContainer;
using Plugins.GameStateMachines;
using Plugins.GameStateMachines.Interfaces;
using Plugins.Interfaces;
using Services.IInputs;
using Services.Interfaces;
using UnityEngine;

namespace Infrastructure.LevelState.States
{
    public class InitGameScene : IEnterState
    {
        private DiBox _diBox = DiBox.MainBox;

        [DI] private LevelStateMachine _levelStateMachine;
        [DI] private ICoroutineRunner _coroutineRunner;
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
            CreateInput();
        }

        private void CreateInput()
        {
            IInput input = null;
            if (Application.isEditor || !Application.isMobilePlatform)
            {
                input = new KeyboardInput();
                _diBox.RegisterSingle<IInput>(input);
            }
            else
                throw new Exception("No input for this platform :(");

            _coroutineRunner.StartCoroutine(UpdateIInput(input));
        }

        private IEnumerator UpdateIInput(IInput input)
        {
            while (true)
            {
                yield return null;
                input.Update();
            }
        }
    }
}