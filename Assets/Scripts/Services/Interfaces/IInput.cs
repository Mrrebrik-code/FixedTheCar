using System;
using UnityEngine;

namespace Services.Interfaces
{
    public interface IInput
    {
        event Action AnyInput;
        event Action<Vector3> RayCastClick;

        void Update();
    }
}