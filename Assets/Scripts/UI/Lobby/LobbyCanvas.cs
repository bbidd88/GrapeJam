using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyCanvas : YCanvas
{
    [SerializeField] private Button StartButton;
    [SerializeField] private Button QuitButton;

    void Awake()
    {
        StartButton.onClick.AddListener(StartButton_OnClick);
        QuitButton.onClick.AddListener(QuitButton_OnClick);
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void StartButton_OnClick()
    {
        SceneManager.LoadScene("GameScene");
        YGame.Get<GameManager>().ClearStage();
    }
    void QuitButton_OnClick()
    {
    }
}
