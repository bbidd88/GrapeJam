using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FieldCanvas : YCanvas
{
    [SerializeField] private GameObject PopupRoot;
    [SerializeField] private Button PasueButton;
    [SerializeField] private TextMeshProUGUI KillCountText;
    
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
    }

    void PasueButton_OnClick()
    {
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

    public void OpenStageClearPopup()
    {
        MonoBehaviour.Instantiate(StageClearPopup, PopupRoot.transform);
    }
}
