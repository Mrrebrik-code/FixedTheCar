using Infrastructure.Configs;
using Infrastructure.LevelState.States;
using Mechanics.Interfaces;
using Plugins.DIContainer;
using Plugins.GameStateMachines;
using Plugins.Interfaces;
using Services.Interfaces;
using UnityEngine;

namespace Infrastructure.LevelState.SceneScripts
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private AbsPrompter _absPrompter;
        
        [DI] private LevelStateMachine _levelStateMachine;
        [DI] private ConfigLocalization _configLocalization;
        [DI] private IInput _input;
        [DI] private Curtain _curtain;

        private void Awake()
        {
            _absPrompter.Unfade(() =>
            {
                _absPrompter.Say(_configLocalization.Wellcome);
                _input.AnyInput += OnAnyInput;
            });
        }

        private void OnAnyInput()
        {
            _input.AnyInput -= OnAnyInput;
            _absPrompter.Fade();
            _curtain.Fade(()=>_levelStateMachine.Enter<Garage>());
        }
    }
}