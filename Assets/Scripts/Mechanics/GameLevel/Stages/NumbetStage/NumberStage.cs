using System;
using System.Linq;
using Factories;
using Mechanics.GameLevel.Datas;
using Mechanics.GameLevel.Stages.NumbetStage.StateMachine;
using Plugins.DIContainer;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Mechanics.GameLevel.Stages.NumbetStage
{
    public class NumberStage : Stage
    {
        public override SizeElement SizeElement => _sizeElement;
        [SerializeField] private SizeElement _sizeElement;
        
        [SerializeField] private Engine _engine;
        [SerializeField] private BoxGenerator _boxGenerator;
        [SerializeField] private BoxClickHandler _clickHandler;
        [SerializeField] private NumberStageStateMachine _numberStageStateMachine;

        [DI] private FactorySpark _factorySpark;
        
        private NumberDataStage _data;
        private NumberDataStage.MathPattern _currentMathExpamle;

        public override void Init(StageData stageData)
        {
            if(!(stageData is NumberDataStage))
                throw new Exception("Wrond data, needed - "+ typeof(NumberDataStage));
            _data = stageData as NumberDataStage;
        }

        public override void Start()
        {
            _engine.Completed += OnCompletedEngine;
            _engine.NewStage += OnNewStage;
            _clickHandler.FailClick += OnFailClick;
            _numberStageStateMachine.StartMe();
        }

        public string CurrentPatternString() => _currentMathExpamle.GetPatternString();

        private void OnFailClick() => ChangePatternWithOdinaryResult();

        private void OnCompletedEngine()
        {
            _boxGenerator.RemoveBox();
            Completed?.Invoke();
        }

        private void OnNewStage() => CreateBox();

        private void CreateBox() 
            => _clickHandler.Init(_boxGenerator.GenerateBox(_data, _currentMathExpamle = _data.RandomPattern), _currentMathExpamle, _engine);

        private void ChangePatternWithOdinaryResult()
        {
            var listPattern = _data.Patterns.Where(x => x.FinalValue == _currentMathExpamle.FinalValue).ToList();
            _currentMathExpamle = listPattern[Random.Range(0, listPattern.Count)];
        }
    }
}