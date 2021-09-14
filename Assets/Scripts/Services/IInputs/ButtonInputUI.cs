using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Services.IInputs
{
    public class ButtonInputUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action ClickUp;
        public event Action ClickDown;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            ClickDown?.Invoke();
            Debug.Log("Down");
        }

        public void OnPointerUp(PointerEventData eventData) => ClickUp?.Invoke();
    }
}