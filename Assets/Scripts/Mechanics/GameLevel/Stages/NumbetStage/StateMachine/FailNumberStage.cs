using Factories;
using Infrastructure.Configs;
using Plugins.DIContainer;
using Services.Interfaces;
using UnityEngine;

namespace Mechanics.GameLevel.Stages.StateMachine
{
    public class FailNumberStage : NumberStageState
    {
        [SerializeField] private MathPatternState _mathPatternState;
        
        [DI] private IInput _input;
        [DI] private FactoryPrompter _factoryPrompter;
        [DI] private ConfigLocalization _configLocalization;

        private NumberStageState _stateToTransit;
        
        public override void On()
        {
            var emotion = Random.Range(0, 1f) > 0.5f ? FactoryPrompter.Type.Fun : FactoryPrompter.Type.WTF;
            _factoryPrompter.ChangeAndSayNoneAnimated(emotion, _configLocalization.NonPraiseNumber);
            _input.AnyInput += OnAnyInput;
        }

        public override void Off()
        {
            _input.AnyInput -= OnAnyInput;
            _stateToTransit = null;
        }

        public override State TransitToOrNull() => _stateToTransit;

        private void OnAnyInput() => _stateToTransit = _mathPatternState;
    }
}