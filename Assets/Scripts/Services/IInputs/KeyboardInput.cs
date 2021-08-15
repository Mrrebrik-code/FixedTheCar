using System;
using Services.Interfaces;
using UnityEngine;

namespace Services.IInputs
{
    public class KeyboardInput : IInput
    {
        public event Action AnyInput;
        
        
        public void Update()
        {
            if(Input.anyKey) AnyInput?.Invoke();
        }
    }
}