using System;
using System.Collections;
using Infrastructure.Configs;
using Plugins.DIContainer;
using Plugins.GameStateMachines;
using Plugins.GameStateMachines.Interfaces;
using Plugins.Interfaces;
using Plugins.Sound;
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
        [DI] private ConfigGame _configGame;

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
            _diBox.RegisterSingle(new SoundSystem(_configGame.TemplateSource, _configGame.startSizePoolSource));
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