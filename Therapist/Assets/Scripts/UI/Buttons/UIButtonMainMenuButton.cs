using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonMainMenuButton : UIButton
{
    public EGameScreen newGameScreen = EGameScreen.MainMenu;

    public override void Start()
    {
        base.Start();
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

    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        MainManager.SetCurrentScreen(newGameScreen);
    }
}
