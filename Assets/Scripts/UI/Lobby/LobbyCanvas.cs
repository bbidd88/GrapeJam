using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyCanvas : YCanvas
{
    [SerializeField] private Button StartButton;
    [SerializeField] private Button QuitButton;

    private void Awake()
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
    }
    void QuitButton_OnClick()
    {
    }
}
