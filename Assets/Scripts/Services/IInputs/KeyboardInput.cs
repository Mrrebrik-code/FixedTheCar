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

        public void Update()
        {
            if(Input.anyKey) AnyInput?.Invoke();
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Click 1 прошел");
                //if(EventSystem.current.IsPointerOverGameObject())
                    //return;
                Debug.Log("Click 2 прошел");
                RayCastClick?.Invoke(Input.mousePosition);
            }
        }
    }
}