using System;
using Plugins.DIContainer;
using Services.Interfaces;
using UnityEngine;

namespace Mechanics
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [Min(0)][SerializeField]private float _speed;

        [DI] private IInput _input;

        [DI]
        private void Init() => enabled = false;

        private void Awake() => Off();

        private void OnEnable()
        {
            _input.NormalizeHorizontalMove += OnHorizontalMove;
            _rigidbody2D.simulated = _collider.enabled = true;
        }

        private void OnDisable() => Off();

        private void Off()
        {
            _input.NormalizeHorizontalMove -= OnHorizontalMove;
            _rigidbody2D.simulated = _collider.enabled = false;
        }

        private void OnHorizontalMove(float deltaHorizontalMove) => _rigidbody2D.velocity=new Vector2(deltaHorizontalMove*_speed, 0);
    }
}