using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Services.IInputs
{
    public class ButtonInputUI : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public event Action ClickUp;
        public event Action ClickDown;
        
        public void OnPointerUp(PointerEventData eventData) => ClickUp?.Invoke();

        public void OnPointerDown(PointerEventData eventData) => ClickDown?.Invoke();
    }
}