using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FieldCanvas : YCanvas
{
    [SerializeField] private GameObject PopupRoot;
    [SerializeField] private Button PasueButton;
    [SerializeField] private TextMeshProUGUI KillCountText;
    [SerializeField] private TextMeshProUGUI RemainTimeText;

    // popup
    [SerializeField] private MenuPoup MenuPoup;
    [SerializeField] private GameOverPopup GameOverPopup;
    [SerializeField] private StageClearPopup StageClearPopup;

    private YPopup PopupInst;

    void Awake()
    {
        PasueButton.onClick.AddListener(PasueButton_OnClick);
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        UpdateKillCount();
        UpdateRemainTime();
    }

    void PasueButton_OnClick()
    {
        if (PopupRoot.transform.childCount > 0)
            return;
        
        MonoBehaviour.Instantiate(MenuPoup, PopupRoot.transform);
        YGame.Get<GameManager>().SetPause(true);
    }
    
    void UpdateKillCount()
    {
        var stageData = YGame.Get<GameManager>().GetCurStageData();
        if (!stageData)
            return;

        int curKill = YGame.Get<GameManager>().GetInfo().Kill;
        int maxKill = stageData.MonsterCount;
        
        KillCountText.text = string.Format("{0} / {1}", curKill, maxKill);
    }

    void UpdateRemainTime()
    {
        var stageData = YGame.Get<GameManager>().GetCurStageData();
        if (!stageData)
            return;
        float elapsedTime = YGame.Get<GameManager>().ElapsedTime;

        RemainTimeText.text = (stageData.TimeLimitSec - elapsedTime).ToString("F2");
    }

    public void OpenStageClearPopup()
    {
        MonoBehaviour.Instantiate(StageClearPopup, PopupRoot.transform);
        YGame.Get<GameManager>().SetPause(true);
    }

    public void OpenGameOverPopup()
    {
        MonoBehaviour.Instantiate(GameOverPopup, PopupRoot.transform);
        YGame.Get<GameManager>().SetPause(true);
    }
}
