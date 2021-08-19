using System;
using Services.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Services.IInputs
{
    public class KeyboardInput : IInput
    {
        public event Action AnyInput;
        public event Action<Vector3> RayCastClick;

        public Vector3 InputScreenPosition => Input.mousePosition;

        public void Update()
        {
            if(Input.anyKey) AnyInput?.Invoke();
            if (Input.GetMouseButtonDown(0))
            {
                if(EventSystem.current.IsPointerOverGameObject())
                    return;
                RayCastClick?.Invoke(Input.mousePosition);
            }
        }
    }
}