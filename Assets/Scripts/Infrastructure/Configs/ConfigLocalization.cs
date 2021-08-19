using TMPro;
using UnityEngine;

namespace Infrastructure.Configs
{
    [CreateAssetMenu(menuName = "Config/localization", order = 51)]
    public class ConfigLocalization : ScriptableObject
    {
        [Header("Шрифт локализации")]
        public TMP_FontAsset FontLocal;
        [Header("Меню")]
        [TextArea(1, 4)] public string Wellcome;
        [TextArea(1, 4)] public string FirstFixCar;
        [TextArea(1, 4)] public string HowToStartGame;
        [Header("Number Stage")]
        [TextArea(1, 4)] public string HellowNumberStage;
        [TextArea(1, 4)] public string HellowNumberStage2;
        [TextArea(1, 4)] public string EndNumbeerStage;
        [TextArea(1, 4)] public string PraiseNumber;
        [TextArea(1, 4)] public string NonPraiseNumber;
        [Header("Electro Stage")]
        [TextArea(1, 4)] public string TakeAnyWire;
        [TextArea(1, 4)] public string HellowElectroStage;
        [TextArea(1, 4)] public string CorrectSetWires;
        [TextArea(1, 4)] public string FailSetWires;
        [TextArea(1, 4)] public string FailElectroMove;
        [TextArea(1, 4)] public string StartTapeStage;
        [TextArea(1, 4)] public string FinishElectroStage;
    }
}