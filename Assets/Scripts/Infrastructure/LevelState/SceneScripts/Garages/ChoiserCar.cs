using Factories;
using Infrastructure.Configs;
using Mechanics.Garage;
using Plugins.DIContainer;
using UnityEngine;

namespace Infrastructure.LevelState.SceneScripts.Garages
{
    public class ChoiserCar : MonoBehaviour
    {
        [SerializeField] private InitGarage _initGarage;
        [SerializeField] private FactoryPrompter _factoryPrompter;
        
        [DI] private SelectorCar _selectorCar;
        [DI] private ConfigLocalization _configLocalization;

        private void Awake() => _initGarage.Inited += OnInited;

        private void OnInited()
        {
            _initGarage.Inited -= OnInited;
            _selectorCar.On();
            _selectorCar.NewCarSelect += OnNewCarSelect;
        }

        private void OnNewCarSelect(Car obj)
        {
            if(!obj)
                return;
            _selectorCar.NewCarSelect -= OnNewCarSelect;
            _factoryPrompter.Current.Say(_configLocalization.HowToStartGame);
        }

        private void OnDestroy()
        {
            _selectorCar.Off();
        }
    }
}