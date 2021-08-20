using System;
using Mechanics.Interfaces;
using UnityEngine;

namespace Mechanics.GameLevel.Stages
{
    public abstract class Stage : MonoBehaviour
    {
        public Action Completed;
        public abstract SizeElement SizeElement { get; }
        public abstract void Start(Player player, bool isInstantaneousTransit);
        public abstract void Init(StageData stageData);
    }
}