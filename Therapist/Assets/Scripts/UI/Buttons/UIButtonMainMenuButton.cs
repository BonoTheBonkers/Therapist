using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonMainMenuButton : MonoBehaviour
{
    public EGameScreen newGameScreen = EGameScreen.MainMenu;
    
    protected Button button;

    public void Start()
    {
        button = GetComponentInChildren<Button>();
        if (button)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    public void OnEnable()
    {
    }

    public void OnDisable()
    {
    }

    public void Update()
    {
        if (!isActiveAndEnabled)
        {
            return;
        }
    }

    protected void OnButtonClick()
    {
        MainManager.SetCurrentScreen(newGameScreen);
    }
}
