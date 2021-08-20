using System;
using DG.Tweening;
using Mechanics.Interfaces;
using UnityEngine;

namespace Mechanics.TransitPlayer
{
    public class MovePlayerToPoint : AbsTransitPlayer
    {
        [SerializeField] private Transform _point;
        [SerializeField] private float _duration;
        
        private void Awake()
        {
            if(!_point) Debug.LogError("Null point", this);
        }
        
        public override void Transit(Player player,Vector3 pointCamera,  Action callback)
        {
            player.MoveToPoint(_point, _duration, callback);
            Camera.main.transform.DOMove(pointCamera, _duration);
        }
    }
}