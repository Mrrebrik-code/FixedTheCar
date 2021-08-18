using Infrastructure.Configs;
using Plugins.DIContainer;
using TMPro;
using UnityEngine;

namespace Mechanics
{
    [RequireComponent(typeof(TextMeshPro))]
    public class LoaderFontForTMP : MonoBehaviour
    {
        [DI] private ConfigLocalization _localization;

        private void Awake() => GetComponent<TextMeshPro>().font = _localization.FontLocal;
    }
}