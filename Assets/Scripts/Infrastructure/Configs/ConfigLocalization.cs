using UnityEngine;

namespace Infrastructure.Configs
{
    [CreateAssetMenu(menuName = "Config design/localization", order = 51)]
    public class ConfigLocalization : ScriptableObject
    {
        [TextArea(1, 4)] public string Wellcome;
    }
}