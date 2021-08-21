using System.Collections;
using Factories;
using Infrastructure.Configs;
using Plugins.DIContainer;
using Services.Interfaces;
using UnityEngine;

namespace Mechanics.GameLevel.Stages.ElectroStageParts.Machines.State
{
    public class GreetingsElectro : ElectorState
    {
        [SerializeField] private SetWiresState _setWiresState;
        [SerializeField] private InteractWithWirePart _interactWithWire;
        
        [DI] private ConfigLocalization _configLocalization;
        [DI] private FactoryPrompter _factoryPrompter;
        [DI] private IInput _input;

        private bool _transitTo = false;
        
        public override void On()
        {
            StartCoroutine(StopInterectOnNewFrame());
            _factoryPrompter.ChangeAt(FactoryPrompter.Type.Hello);
            _factoryPrompter.Current.Unhide(() =>
            {
                _factoryPrompter.Current.Say(_configLocalization.HelloElectroStage, 
                    ()=>_input.AnyInput += OnAnyInput);
            });
        }

        public override void Off()
        {
            _transitTo = false;
            _input.AnyInput -= OnAnyInput;
        }

        public override Stages.State TransitToOrNull() => _transitTo ? _setWiresState : null; 

        private void OnAnyInput() => _transitTo = true;

        private IEnumerator StopInterectOnNewFrame()
        {
            yield return null;
            _interactWithWire.OffInteract();
        }
    }
}