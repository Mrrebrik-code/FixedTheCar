using System;
using UnityEngine;

namespace Mechanics.GameLevel.Stages.StateMachine
{
    public class NumberStageStateMachine : MonoBehaviour
    {
        [SerializeField] private NumberStageState _startState;

        private NumberStageState _currentState;
        
        private void Awake() => enabled = false;

        public void StartMe()
        {
            if(enabled)
                return;
            _currentState = _startState;
            _currentState.On();
            enabled = true;
        }

        private void Update()
        {
            _currentState.Step();
            CahngeState(_currentState.TransitToOrNull() as NumberStageState);
        }

        private void CahngeState(NumberStageState transitToOrNull)
        {
            if(!transitToOrNull)
                return;
            _currentState.Off();
            _currentState = transitToOrNull;
            _currentState.On();
        }
    }
}