using System;
using ExtendedButtons;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Services.IInputs
{
    [RequireComponent(typeof(Button2D))]
    public class ButtonInputUI : MonoBehaviour
    {
        private Button2D _button2D;
        
        public event Action ClickUp;
        public event Action ClickDown;
        
        private void Awake()
        {
            _button2D = GetComponent<Button2D>();
            _button2D.onDown.AddListener(() => ClickDown?.Invoke());
            _button2D.onUp.AddListener(()=>ClickUp?.Invoke());
        }
    }
}