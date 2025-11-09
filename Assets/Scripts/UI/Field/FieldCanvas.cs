using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FieldCanvas : YCanvas
{
    [SerializeField] private GameObject PopupRoot;
    [SerializeField] private Button PasueButton;

    void Awake()
    {
        PasueButton.onClick.AddListener(PasueButton_OnClick);
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void PasueButton_OnClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
