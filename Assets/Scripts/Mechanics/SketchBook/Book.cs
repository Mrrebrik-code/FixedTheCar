using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mechanics.SketchBook
{
    public class Book : MonoBehaviour
    {
        public Transform ParentForPage => _parentForPage;

        [SerializeField] private Button _nextPageButton;
        [SerializeField] private Button _prevPageButton;
        [SerializeField] private FactoryPage _factoryPage;
        [SerializeField] private float _durationChange = 0.25f;
        [SerializeField] private Transform _parentForPage;
        
        private List<Page> _pages;
        private int _currentPageIndex = 0;

        private void Awake()
        {
            _nextPageButton.onClick.AddListener(OnNextPage);
            _prevPageButton.onClick.AddListener(OnPrevPage);
        }

        private void Start()
        {
            _pages = _factoryPage.CreatePage(this);
            _currentPageIndex = 0;
            _pages[_currentPageIndex].Show(0.0001f);
        }

        private void OnPrevPage()
        {
            if (_currentPageIndex - 1 < 0) return;
            ChangePage(_currentPageIndex - 1);
            _currentPageIndex--;
        }

        private void OnNextPage()
        {
            if (_currentPageIndex + 1 >= _pages.Count) return;
            ChangePage(_currentPageIndex+1);
            _currentPageIndex++;
        }

        private void ChangePage(int newPage)
        {
            ChangeInteractableButtonTo(false);
            _pages[_currentPageIndex].Hide(_durationChange, ()=>
                _pages[newPage].Show(_durationChange,()=>
                    ChangeInteractableButtonTo(true)));
        }

        private void ChangeInteractableButtonTo(bool isActive) => 
            _nextPageButton.interactable = _prevPageButton.interactable = isActive;
    }
}