using System;
using Infrastructure.Configs;
using Plugins.DIContainer;
using TMPro;
using UnityEngine;

namespace Mechanics
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LoaderFontForTMP_UI : MonoBehaviour
    {
        [DI] private ConfigLocalization _localization;

        private void Awake() => GetComponent<TextMeshProUGUI>().font = _localization.FontLocal;
    }
}