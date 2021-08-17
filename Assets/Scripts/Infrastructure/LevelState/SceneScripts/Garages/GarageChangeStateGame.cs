using System;
using Infrastructure.Configs;
using Infrastructure.LevelState.States;
using Mechanics.Garage;
using Plugins.DIContainer;
using Plugins.GameStateMachines;
using Plugins.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.LevelState.SceneScripts.Garages
{
    public class GarageChangeStateGame : MonoBehaviour
    {
        [SerializeField] private Button _buttonNextLevel;
        
        [DI] private SelectorCar _selectorCar;
        [DI] private LevelStateMachine _levelStateMachine;
        [DI] private Curtain _curtain;

        private void Awake()
        {
            ChangeButtonIntractable(_selectorCar.SelectedCar);
            _selectorCar.NewCarSelect += OnNewCarSelect;
            _buttonNextLevel.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            _curtain.Fade(()=>_levelStateMachine.Enter<GameScene, ConfigLevel>(_selectorCar.SelectedCar.LevelConfigCar));
            _selectorCar.Off();
        }

        private void OnDestroy() => _selectorCar.NewCarSelect -= OnNewCarSelect;

        private void OnNewCarSelect(Car obj) => ChangeButtonIntractable(obj);

        private void ChangeButtonIntractable(Car obj) => _buttonNextLevel.interactable = obj != null;
    }
}