using Factories;
using Mechanics.GameLevel.Stages.СanistorStageParts.StateMAchine;
using UnityEngine;

namespace Mechanics.GameLevel.Stages.СanistorStageParts.States
{
    public class GreetingCanistroStage : CanistroStageState
    {
        [SerializeField] private ShowCanistroStage _stateToTransit;

        private bool _isTransit;
        
        public override void On()
        {
            FactoryPrompter.ChangeAt(FactoryPrompter.Type.Hello);
            FactoryPrompter.Current.Unhide(()=>FactoryPrompter.Current.Say(ConfigLocalization.HelloCanistorStage, ()=>InputPlayer.AnyInput+=OnAnyKey));
        }

        private void OnAnyKey()
        {
            InputPlayer.AnyInput -= OnAnyKey;
            _isTransit = true;
        }

        public override void Off() => _isTransit = false;

        public override State TransitToOrNull() => _isTransit ? _stateToTransit : null;
    }
}