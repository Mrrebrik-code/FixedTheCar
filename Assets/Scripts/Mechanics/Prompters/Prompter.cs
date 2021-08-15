using System;
using Mechanics.Interfaces;
using UnityEngine;

namespace Mechanics.Prompters
{
    public class Prompter : AbsPrompter
    {
        public override void Unfade(Action action = null)
        {
            Debug.Log("Появился");
            action?.Invoke();
        }

        public override void Say(string message)
        {
            Debug.Log("Сказал = "+message);
        }

        public override void Fade(Action action = null)
        {
            Debug.Log("Спрятался");
            action?.Invoke();
        }
    }
}