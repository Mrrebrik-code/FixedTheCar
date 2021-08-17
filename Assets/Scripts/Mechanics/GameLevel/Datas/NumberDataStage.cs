using System.Collections.Generic;
using Mechanics.GameLevel.Stages;
using Mechanics.Interfaces;
using UnityEngine;

namespace Mechanics.GameLevel.Datas
{
    [CreateAssetMenu(menuName = "Config/Stages/Numbers", order = 51)]
    public class NumberDataStage : StageData
    {
        public int Min;
        public int Max;
        public List<MathPattern> Patterns;

        protected override bool ValidateMethod(Stage stageTocheck)
        {
            if (Min >= Max)
                Min = Max - 1;
            for (int i = 0; i < Patterns.Count; i++)
            {
                int finalValue = Patterns[i].FinalValue;
                if(finalValue<Min || finalValue>Max)
                    Debug.LogWarning($"У {name} пример номер {i} не входит в заданные пределы. Исправьте либо пределы, либо пример");
            }
            return stageTocheck is NumberStage;
        }

        [System.Serializable]
        public class MathPattern
        {
            public int FinalValue
            {
                get
                {
                    int result = 0;
                    foreach (var VARIABLE in Numbers)
                        result += VARIABLE;
                    return result;
                }
            }
            public List<int> Numbers;
        }
    }

    
}