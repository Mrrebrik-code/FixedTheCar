using System;
using Mechanics.GameLevel.Stages.ElectroStageParts.Machines;
using Services.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Services.IInputs
{
    public class KeyboardInput : IInput
    {
        public event Action AnyInput;
        public event Action<Vector3> RayCastClick;
        public event Action<float> NormalizeHorizontalMove;

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
            if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                NormalizeHorizontalMove?.Invoke(0);
            else if(Input.GetKey(KeyCode.A))
                NormalizeHorizontalMove?.Invoke(-1);
            else if(Input.GetKey(KeyCode.D))
                NormalizeHorizontalMove?.Invoke(1);
            else
                NormalizeHorizontalMove?.Invoke(0);
        }
    }
}