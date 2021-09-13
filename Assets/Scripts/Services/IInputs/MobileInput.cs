using System;
using Mechanics.GameLevel.Stages.ElectroStageParts.Machines;
using Services.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Services.IInputs
{
	public class MobileInput : IInput, IShowHide
	{
		public Vector3 InputScreenPosition => GetScreenPositionByLastClick();
		public event Action AnyInput;
		public event Action<Vector3> RayCastClick;
		public event Action<float> NormalizeHorizontalMove;

		private float _xDiraction=0;
		private Vector2 _lastPosition;
		private CanvasUiInput _canvasInput;

		public MobileInput(CanvasUiInput canvasInput)
		{
			_canvasInput = canvasInput;
			_canvasInput.LeftButton.ClickDown += LeftDown;
			_canvasInput.LeftButton.ClickUp += LeftUp;
			_canvasInput.RightButton.ClickDown += RightDown;
			_canvasInput.RightButton.ClickUp += RightUp;
			_canvasInput.Hide();
		}

		private Vector3 GetScreenPositionByLastClick()
		{
			if (Input.touchCount > 0) _lastPosition = Input.GetTouch(0).position;
			return _lastPosition;
		}

		public void Update()
		{
			if (Input.touchCount>0) AnyInput?.Invoke();
			if (Input.touchCount>0)
			{
				if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
					return;
				RayCastClick?.Invoke(Input.GetTouch(0).position);
			}
			NormalizeHorizontalMove?.Invoke(_xDiraction);
		}

		private void RightUp()
		{
			if (_xDiraction == 1) _xDiraction = 0;
		}

		private void RightDown() => _xDiraction = 1;

		private void LeftUp()
		{
			if (_xDiraction == -1) _xDiraction = 0;
		}

		private void LeftDown() => _xDiraction = -1;

		public void Show() => _canvasInput.Show();

		public void Hide() => _canvasInput.Hide();
	}
}
