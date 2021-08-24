using System;
using System.Collections.Generic;
using DG.Tweening;
using Factories;
using Infrastructure.Configs;
using UnityEngine;

namespace Mechanics.SketchBook
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Page : MonoBehaviour
    {
        [SerializeField] private List<Sticker> _stickers;

        private CanvasGroup _canvasGroup;
        
        private void Awake() => _canvasGroup = GetComponent<CanvasGroup>();

        public void Init(in List<ConfigLevel> levels, out List<ConfigLevel> usedConfigs)
        {
            usedConfigs = new List<ConfigLevel>();
            for (int i = 0; i < _stickers.Count; i++)
            {
                if(i>=levels.Count)
                    break;
                Debug.Log("Used config " + levels[i].name + " Stiker - "+levels[i].Stiker.name);
                _stickers[i].Init(levels[i]);
                usedConfigs.Add(levels[i]);
            }
        }

        public void Show(float duration, Action callback = null) => 
            _canvasGroup.DOFade(1, duration).OnComplete(()=>
            {
                _canvasGroup.interactable = true;
                callback?.Invoke();
            });

        public void Hide(float duration, Action callback = null) => 
            _canvasGroup.DOFade(0, duration).OnStart(()=>_canvasGroup.interactable = false).OnComplete(()=>callback?.Invoke());
    }
}