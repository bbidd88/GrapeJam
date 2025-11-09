using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPoup : YPopup
{
    [SerializeField] private Button RetunrButton;
    [SerializeField] private Button QuitButton;

    void Awake()
    {
        RetunrButton.onClick.AddListener(RetunrButton_OnClick);
        QuitButton.onClick.AddListener(QuitButton_OnClick);
    }
    
    void RetunrButton_OnClick()
    {
        YGame.Get<GameManager>().SetPause(false);
        Close();
    }

    void QuitButton_OnClick()
    {
        SceneManager.LoadScene("StartScene");
        Close();
    }
}
