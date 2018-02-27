using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonReturn : MonoBehaviour
{
    protected Button button;

    public void Start()
    {
        button = GetComponentInChildren<Button>();
        if (button)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }
    
    protected void OnButtonClick()
    {
        if(MainManager.GetCurrentScreen() == EGameScreen.Board)
        {
            MainManager.SetCurrentScreen(EGameScreen.AttributeMenu);
        }
        else
        {
            MainManager.SetCurrentScreen(EGameScreen.MainMenu);
        }
    }
    
}
