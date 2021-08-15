using System;
using UnityEngine;

namespace Mechanics.Interfaces
{
    public abstract class AbsPrompter : MonoBehaviour
    {
        public abstract void Unfade(Action action = null);

        public abstract void Say(string message);

        public abstract void Fade(Action action = null);
    }
}