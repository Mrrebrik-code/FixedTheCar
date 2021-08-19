using System;
using Mechanics.GameLevel.Stages.ElectroStage.Machines;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Mechanics.GameLevel.Stages.ElectroStage
{
    public class ElectroStage : Stage
    {
        public override SizeElement SizeElement { get; }
        public int MaxBreakeWires => _wires.MaxBreakePart;

        [SerializeField] private ElectroStageStateMachine _stateMachine;
        [SerializeField] private Wires _wires;
        [SerializeField] private ElectroPath electroPath;

        private ElectroStageData _stageData;
        
        public override void Start()
        {
            _stateMachine.StartMe();
            _wires.Break(Random.Range(_stageData.MinBreakWires, _stageData.MaxBreakeWires+1));
            electroPath.Finished += OnFinished;
        }

        private void OnFinished()
        {
            electroPath.Finished -= OnFinished;
            Completed?.Invoke();
        }

        public override void Init(StageData stageData)
        {
            _stageData = stageData as ElectroStageData;
            if(!_stageData)
                throw new Exception("Wrong Data");
        }
    }
}