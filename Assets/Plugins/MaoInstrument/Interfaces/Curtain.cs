using System;
using UnityEngine;

namespace Plugins.Interfaces
{
    public abstract class Curtain : MonoBehaviour
    {
        public abstract event Action Unfaded;
        public abstract void Fade(Action callback);
        public abstract void Fade(Action callback, float duration);
        public abstract void Unfade();
        public abstract void Transit(Action callback);
    }
}