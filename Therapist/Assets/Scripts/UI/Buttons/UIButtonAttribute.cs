﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonAttribute : UIButton
{
    public EAttribute attribute = EAttribute.Amounts;
    public Text percentage;
    public Image fillImageFull;

    protected float currentPercentage = 0.0f;
    protected float targetPercentage = 1.0f;
    protected float percentageDifference = 0.0f;
    
    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        MainManager.SetCurrentAttribute(attribute);
        MainManager.SetCurrentScreen(EGameScreen.Board);
    }

    public void OnEnable()
    {
        EventManager.StartListening(EventManager.OnCurrentLevelChanged, ReloadPercentage);
        EventManager.StartListening(EventManager.OnPlayerChanged, ReloadPercentage);
        currentPercentage = 0.0f;
        percentageDifference = Mathf.Abs(currentPercentage - targetPercentage);
        ReloadPercentage();
    }

    public void OnDisable()
    {
        EventManager.StopListening(EventManager.OnCurrentLevelChanged, ReloadPercentage);
        EventManager.StopListening(EventManager.OnPlayerChanged, ReloadPercentage);
    }

    public void Update()
    {
        if (!isActiveAndEnabled)
        {
            return;
        }

        if (currentPercentage != targetPercentage && percentageDifference != 0.0f)
        {
            if(targetPercentage > currentPercentage)
            {
                currentPercentage = Mathf.Min(currentPercentage + (Time.deltaTime * 0.9f * percentageDifference), targetPercentage);
            }
            else if(targetPercentage < currentPercentage)
            {
                currentPercentage = Mathf.Max(currentPercentage - (Time.deltaTime * 0.9f * percentageDifference), targetPercentage);
            }
        }

        if (percentage)
        {
            percentage.text = ((int)(Mathf.Round(currentPercentage * 100.0f))).ToString() + "%";
        }
        if (fillImageFull)
        {
            fillImageFull.fillAmount = currentPercentage;
        }
    }
    
    protected void ReloadPercentage()
    {
        targetPercentage = MainManager.GetAttributeProgressPercentageAtCurrentLevel(attribute);
        percentageDifference = Mathf.Abs(currentPercentage - targetPercentage);
    }
}
