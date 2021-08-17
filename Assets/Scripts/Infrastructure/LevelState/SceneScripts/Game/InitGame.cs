using System;
using System.Collections.Generic;
using Infrastructure.Configs;
using Mechanics.Interfaces;
using Plugins.DIContainer;
using Plugins.Interfaces;
using UnityEngine;

namespace Infrastructure.LevelState.SceneScripts.Game
{
    public class InitGame : MonoBehaviour
    {
        public event Action<List<Stage>> Inited;
        
        [DI] private Curtain _curtain;
        [DI] private ConfigLevel _configLevel;

        private DiBox _diBox = DiBox.MainBox;
        
        private void Start()
        {
            var stages = CreateStages();
            _curtain.Unfade();
            stages[0].ApplayPlayer();
            Inited?.Invoke(stages);
        }

        private List<Stage> CreateStages()
        {
            List<Stage> result = new List<Stage>();
            foreach (var stageData in _configLevel.StagesLevel)
            {
                var stage = _diBox.CreatePrefab(stageData.StageTemplate);
                stage.Init(stageData);
                stage.transform.position = result.Count == 0 ? Vector3.zero : GetPositionStage(result[result.Count - 1], stage);
                result.Add(stage);
            }

            return result;
        }

        private Vector3 GetPositionStage(Stage prev, Stage current)
        {
            Vector3 result = prev.transform.position;
            Vector3 offset = new Vector3(prev.SizeElement.Size.x/2+current.SizeElement.Size.x/2, 0, 0);
            return result + offset;
        }
    }
}