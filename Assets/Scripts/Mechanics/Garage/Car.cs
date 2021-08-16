using System;
using Infrastructure.Configs;
using UnityEngine;

namespace Mechanics.Garage
{
    [RequireComponent(typeof(Collider2D))]
    public class Car : MonoBehaviour
    {
        public ConfigLevel LevelConfigCar { get; private set; }
        public event Action Selected;

        public void Init(ConfigLevel configLevel) => LevelConfigCar = configLevel;

        public Car Select()
        {
            Selected?.Invoke();
            return this;
        }
        public void Unselect(){}
    }
}