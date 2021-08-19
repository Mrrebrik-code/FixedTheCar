using Factories;
using Infrastructure.Configs;
using Plugins.DIContainer;

namespace Mechanics.GameLevel.Stages.ElectroStage.Machines.State
{
    public class EndingElectro : ElectorState
    {
        [DI] private FactoryPrompter _factoryPrompter;
        [DI] private ConfigLocalization _configLocalization;
        
        public override void On()
        {
            _factoryPrompter.ChangeAt(FactoryPrompter.Type.Idea);
            _factoryPrompter.Current.Say(_configLocalization.FinishElectroStage);
        }

        public override void Off()
        {
        }

        public override Stages.State TransitToOrNull() => null;
    }
}