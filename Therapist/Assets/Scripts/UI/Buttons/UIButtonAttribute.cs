﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonAttribute : MonoBehaviour
{
    public EAttribute attribute = EAttribute.Amount;
    public Text percentage;
    public Image fillImageFull;
    protected Button button;

    protected float currentPercentage = 0.0f;
    protected float targetPercentage = 1.0f;

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
        EventManager.StartListening("OnCurrentLevelChanged", ReloadPercentage);
        currentPercentage = 0.0f;
        ReloadPercentage();
    }

    public void OnDisable()
    {
        EventManager.StopListening("OnCurrentLevelChanged", ReloadPercentage);
    }

    public void Update()
    {
        if (!isActiveAndEnabled)
        {
            return;
        }

        if (currentPercentage != targetPercentage)
        {
            if(targetPercentage > currentPercentage)
            {
                currentPercentage = Mathf.Min(currentPercentage + (Time.deltaTime * 0.6f), targetPercentage);
            }
            else if(targetPercentage < currentPercentage)
            {
                currentPercentage = Mathf.Max(currentPercentage - (Time.deltaTime * 0.6f), targetPercentage);
            }
        }

        if (percentage)
        {
            percentage.text = ((int)(currentPercentage * 100.0f)).ToString() + "%";
        }
        if (fillImageFull)
        {
            fillImageFull.fillAmount = currentPercentage;
        }
    }

    protected void OnButtonClick()
    {
        MainManager.SetCurrentAttribute(attribute);
        MainManager.SetCurrentScreen(EGameScreen.Board);
    }
    
    protected void ReloadPercentage()
    {
        targetPercentage = MainManager.GetAttributeProgressPercentageAtCurrentLevel(attribute);
    }
}
