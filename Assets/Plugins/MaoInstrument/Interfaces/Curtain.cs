using System;
using UnityEngine;

namespace Plugins.Interfaces
{
    public abstract class Curtain : MonoBehaviour
    {
        public abstract void Fade(Action callback);
        public abstract void Unfade();
        public abstract void Transit(Action callback);
    }
}