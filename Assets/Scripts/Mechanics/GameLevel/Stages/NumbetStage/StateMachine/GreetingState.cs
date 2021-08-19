using Factories;
using Infrastructure.Configs;
using Mechanics.Prompters;
using Plugins.DIContainer;
using Services.Interfaces;
using UnityEngine;

namespace Mechanics.GameLevel.Stages.NumbetStage.StateMachine
{
    public class GreetingState : NumberStageState
    {
        [SerializeField] private MathPatternState _mathPatternState;
        [SerializeField] private Engine _engine;
        
        [DI] private IInput _input;
        [DI] private FactoryPrompter _factoryPrompter;
        [DI] private ConfigLocalization _configLocalization;

        private Prompter CurrentPromter => _factoryPrompter.Current;
        private bool _canTransit = false;
        
        public override void On()
        {
            _factoryPrompter.ChangeAt(FactoryPrompter.Type.Hello);
            CurrentPromter.Unhide(
                ()=>CurrentPromter.Say(
                    _configLocalization.HellowNumberStage, 
                    ()=>_input.AnyInput += OnFirstClick)
                );
        }

        public override void Off() => _canTransit = false;

        public override State TransitToOrNull() => _canTransit ? _mathPatternState : null;

        private void OnFirstClick()
        {
            _input.AnyInput -= OnFirstClick;
            CurrentPromter.Say(_configLocalization.HellowNumberStage2, ()=>_input.AnyInput += OnSecondClick);
        }

        private void OnSecondClick()
        {
            _input.AnyInput -= OnSecondClick;
            _engine.GenerateShadow();
            _canTransit = true;
        }
    }
}