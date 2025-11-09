using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageClearPopup : YPopup
{
    [SerializeField] private Button RetryButton;
    [SerializeField] private Button QuitButton;

    void Awake()
    {
        RetryButton.onClick.AddListener(RetryButton_OnClick);
        QuitButton.onClick.AddListener(QuitButton_OnClick);
    }

    void RetryButton_OnClick()
    {
        YGame.Get<GameManager>().ClearStage();
        Close();
    }

    void QuitButton_OnClick()
    {
        SceneManager.LoadScene("StartScene");
        Close();
    }
}
