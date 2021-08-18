using System;
using UnityEngine;

namespace Mechanics.Interfaces
{
    public abstract class Stage : MonoBehaviour
    {
        public Action Completed;
        public abstract SizeElement SizeElement { get; }
        public abstract void Start(/*Player*/);
        public abstract void Init(StageData stageData);
    }
}