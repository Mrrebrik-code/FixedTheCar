using System;
using DG.Tweening;
using UnityEngine;

namespace Mechanics
{
    [RequireComponent(typeof(Animator))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        public void MoveToPoint(Transform point, float duration, Action callback= null) => transform.DOMove(point.position, duration).OnComplete(() => callback?.Invoke());

        public void MakeDirty()
        {
        }

        public void MakeClear()
        {
        }
    }
}