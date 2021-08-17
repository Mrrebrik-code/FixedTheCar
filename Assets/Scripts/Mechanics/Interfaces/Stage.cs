using System;
using UnityEngine;

namespace Mechanics.Interfaces
{
    public abstract class Stage : MonoBehaviour
    {
        public Action Completed;
        public abstract SizeElement SizeElement { get; }
        public abstract void ApplayPlayer(/*Player*/);
        public abstract void RemovePlayer();
        public abstract void Restart();
        public abstract void Init(StageData stageData);
    }
}