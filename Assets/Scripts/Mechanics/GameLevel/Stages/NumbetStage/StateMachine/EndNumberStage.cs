using Factories;
using Infrastructure.Configs;
using Plugins.DIContainer;

namespace Mechanics.GameLevel.Stages.NumbetStage.StateMachine
{
    public class EndNumberStage : NumberStageState
    {
        [DI] private FactoryPrompter _factoryPrompter;
        [DI] private ConfigLocalization _configLocalization;
        
        public override void On() => _factoryPrompter.ChangeAndSayNoneAnimated(FactoryPrompter.Type.Hello, _configLocalization.EndNumbeerStage);

        public override void Off()
        {
        }

        public override State TransitToOrNull() => null;
    }
}