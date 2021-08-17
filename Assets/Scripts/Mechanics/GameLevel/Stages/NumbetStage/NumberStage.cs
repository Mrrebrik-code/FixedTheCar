using System;
using System.Threading.Tasks;
using Factories;
using Infrastructure.Configs;
using Mechanics.GameLevel.Datas;
using Mechanics.Interfaces;
using Plugins.DIContainer;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

namespace Mechanics.GameLevel.Stages
{
    public class NumberStage : Stage
    {
        public override SizeElement SizeElement => _sizeElement;
        [SerializeField] private SizeElement _sizeElement;
        [SerializeField] private Engine _engine;
        [SerializeField] private BoxGenerator _boxGenerator;
        [SerializeField] private BoxClickHandler _clickHandler;

        [DI] private FactorySpark _factorySpark;
        [DI] private FactoryPrompter _factoryPrompter;
        [DI] private ConfigLocalization _localization;
        
        private NumberDataStage _data;
        private NumberDataStage.MathPattern _currentMathExpamle;
        
        public override void ApplayPlayer()
        {
            _engine.Completed += OnCompletedEngine;
            _engine.NewStage += OnNewStage;
            _clickHandler.SuccessClick += OnSuccessClick;
            _clickHandler.FailClick += OnFailClick;
            _engine.GenerateShadow();
        }

        public override void RemovePlayer()
        {
            throw new NotImplementedException();
        }

        public override void Restart() => Debug.LogWarning("This stage with out restart");

        public override void Init(StageData stageData)
        {
            if(!(stageData is NumberDataStage))
                throw new Exception("Wrond data, needed - "+ typeof(NumberDataStage));
            _data = stageData as NumberDataStage;
        }

        private void StartStage()
        {
            _currentMathExpamle = GetRandomPattern();
            _clickHandler.Init(_boxGenerator.GenerateBox(_data, _currentMathExpamle), _currentMathExpamle, _engine);
        }
        
        private void OnFailClick()
        {
            Say(FactoryPrompter.Type.WTF, _localization.NonPraise, async ()=>
            {
                await Task.Delay(900);
                Say(FactoryPrompter.Type.Idea, GetNumberMessageForMouse());
            });
        }

        private void OnSuccessClick() => Say(FactoryPrompter.Type.WTF, _localization.Praise);

        private void OnNewStage()
        {
            StartStage();
            Say(FactoryPrompter.Type.Idea, GetNumberMessageForMouse());
            _factoryPrompter.Current.Unhide();
        }

        private void Say(FactoryPrompter.Type type, string mes, Action callback = null)
        {
            _factoryPrompter.ChangeAt(type);
            _factoryPrompter.Current.Say(mes, () => callback?.Invoke());
        }

        private void OnCompletedEngine()
        {
            _boxGenerator.RemoveBox();
            Completed?.Invoke();
        }

        private string GetNumberMessageForMouse()
        {
            string mes = "";
            foreach (var num in _currentMathExpamle.Numbers)
            {
                if(num>0)
                    mes +="+"+ num.ToString();
                else
                    mes += "-" + num.ToString();
            }

            if (mes[0] == '+')
                mes = mes.Remove(0, 1);
            mes += "=?";
            return mes;
        }

        private NumberDataStage.MathPattern GetRandomPattern() => _data.Patterns[Random.Range(0, _data.Patterns.Count)];
    }
}