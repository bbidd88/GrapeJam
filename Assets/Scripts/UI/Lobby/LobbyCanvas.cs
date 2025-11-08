using UnityEngine;
using UnityEngine.UI;

public class LobbyCanvas : MonoBehaviour
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

    }
    void QuitButton_OnClick()
    {
    }
}
