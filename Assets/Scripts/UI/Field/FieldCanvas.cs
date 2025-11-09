using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FieldCanvas : YCanvas
{
    [SerializeField] private GameObject PopupRoot;
    [SerializeField] private Button PasueButton;
    [SerializeField] private TextMeshProUGUI KillCountText;
    

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
        SceneManager.LoadScene("StartScene");
    }
    
    void UpdateKillCount()
    {
        KillCountText.text = YGame.Get<GameManager>().GetInfo().Kill.ToString();
    }
}
