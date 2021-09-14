using System;
using Factories;
using Plugins.DIContainer;
using Services.Interfaces;
using UnityEngine;

namespace Mechanics
{
    public class ButtonPlayerMover : PlayerMover
    {
        [DI] private IInput _input;

        [DI]
        private void Init() => Off();

        public override void On()
        {
            base.On();
            _input.NormalizeHorizontalMove += OnHorizontalMove;
        }
        
        public override void Off()
        {
            base.Off();
            _input.NormalizeHorizontalMove -= OnHorizontalMove;
        }

        private void OnHorizontalMove(float deltaHorizontalMove)
        {
            Rigidbody2D.velocity = new Vector2(deltaHorizontalMove * Speed, 0);
            Player.SetMoveAnimationActive(deltaHorizontalMove!=0);
            if (deltaHorizontalMove > 0)
                SpriteRenderer.flipX = false;
            else if (deltaHorizontalMove < 0)
                SpriteRenderer.flipX = true;
        }
    }
}