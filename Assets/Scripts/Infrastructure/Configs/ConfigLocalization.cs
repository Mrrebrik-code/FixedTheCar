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
        public AudioClip WelcomeClip;
        [TextArea(1, 4)] public string FirstFixCar;
        public AudioClip FirstFixCarClip;
		[TextArea(1, 4)] public string HowToStartGame;
        public AudioClip HowToStartGameClip;
		[TextArea(1, 4)] public string SketchBookHello;
        public AudioClip SketchBookHelloClip;
		[Header("Number Stage")]
		[TextArea(1, 4)] public string HelloNumberStage;
        public AudioClip HelloNumberStageClip;
		[TextArea(1, 4)] public string HelloNumberStage2;
        public AudioClip HelloNumberStage2Clip;
		[TextArea(1, 4)] public string EndNumberStage;
        public AudioClip EndNumberStageClip;
		[TextArea(1, 4)] public string PraiseNumber;
        public AudioClip PraiseNumberClip;
		[TextArea(1, 4)] public string NonPraiseNumber;
        public AudioClip NonPraiseNumberClip;
		[Header("Electro Stage")]
		[TextArea(1, 4)] public string TakeAnyWire;
        public AudioClip TakeAnyWireClip;
		[TextArea(1, 4)] public string HelloElectroStage;
        public AudioClip HelloElectroStageClip;
		[TextArea(1, 4)] public string CorrectSetWires;
        public AudioClip CorrectSetWiresClip;
		[TextArea(1, 4)] public string FailSetWires;
        public AudioClip FailSetWiresClip;
		[TextArea(1, 4)] public string FailElectroMove;
        public AudioClip FailElectroMoveClip;
		[TextArea(1, 4)] public string StartTapeStage;
        public AudioClip StartTapeStageClip;
		[TextArea(1, 4)] public string FinishElectroStage;
        public AudioClip FinishElectroStageClip;
		[Header("Canistro Stage")]
		[TextArea(1, 4)] public string HelloCanistorStage;
        public AudioClip HelloCanistorStageClip;
		[TextArea(1, 4)] public string HelloCanistorStage2;
        public AudioClip HelloCanistorStage2Clip;
		[TextArea(1, 4)] public string ChooseAnyCanisters;
        public AudioClip ChooseAnyCanistersClip;
		[TextArea(1, 4)] public string СorrectlyChooseCanistro;
        public AudioClip СorrectlyChooseCanistroClip;
		[TextArea(1, 4)] public string FailChooseCanistro;
        public AudioClip FailChooseCanistroClip;
		[TextArea(1, 4)] public string EndCanistrostage;
        public AudioClip EndCanistrostageClip;
		[Header("BossStage")]
		[TextArea(1, 4)] public string HelloBossStage;
        public AudioClip HelloBossStageClip;
		[TextArea(1, 4)] public string LoseBossStage;
        public AudioClip LoseBossStageClip;
		[TextArea(1, 4)] public string WinBossStage;
        public AudioClip WinBossStageClip;
    }
}