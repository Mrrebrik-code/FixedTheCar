using System;

namespace Services.Interfaces
{
    public interface IInput
    {
        event Action AnyInput;

        void Update();
    }
}