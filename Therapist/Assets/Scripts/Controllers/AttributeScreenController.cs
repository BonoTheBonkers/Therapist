using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeScreenController : SingletonManager<AttributeScreenController>
{
    public Text text;
    public AnimationCurve alphaCurve;
    private float currentTime = 0.0f;
    private float targetTime = 2.0f;
    private bool shouldBeActive = false;

    private CanvasGroup canvasGroup;

    void OnEnable()
    {
        GetCanvasGroup().alpha = 0.0f;
        GetCanvasGroup().blocksRaycasts = false;
        EventManager.StartListening(EventManager.OnCurrentAttributeChanged, OnAttributeChanged);
        EventManager.StartListening(EventManager.OnCurrentScreenChanged, OnCurrentScreenChanged);
        EventManager.StartListening(EventManager.OnConfirmScreenShowed, ForceHideScreen);
    }
    void OnDisable()
    {
        EventManager.StopListening(EventManager.OnCurrentAttributeChanged, OnAttributeChanged);
        EventManager.StopListening(EventManager.OnCurrentScreenChanged, OnCurrentScreenChanged);
        EventManager.StopListening(EventManager.OnConfirmScreenShowed, ForceHideScreen);
    }

    public CanvasGroup GetCanvasGroup()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponentInParent<CanvasGroup>();
        }

        return canvasGroup;
    }

    public void OnAttributeChanged()
    {
        if (GetCanvasGroup() == null)
        {
            return;
        }

        ReloadCurrentAttribute();
        currentTime = 0.0f;
        //GetCanvasGroup().blocksRaycasts = true;
        shouldBeActive = true;
    }

    public void OnCurrentScreenChanged()
    {
        if (MainManager.GetCurrentScreen() != EGameScreen.Board)
        {
            HideScreen(true);
        }
    }

    public void ForceHideScreen()
    {
        HideScreen(true);
    }

    protected void HideScreen(bool IsForced)
    {
        GetCanvasGroup().alpha = 0.0f;
        GetCanvasGroup().blocksRaycasts = false;
        shouldBeActive = false;
    }

    void Update()
    {
        if (!shouldBeActive || GetCanvasGroup() == null)
        {
            return;
        }

        currentTime = Mathf.Min(currentTime + Time.deltaTime, targetTime);
        if (currentTime >= targetTime)
        {
            HideScreen(false);
        }
        else
        {
            GetCanvasGroup().alpha = alphaCurve.Evaluate(currentTime / targetTime);
        }
    }
    protected void ReloadCurrentAttribute()
    {
        if (MainManager.GetCurrentAttribute() == EAttribute.Amounts)
        {
            text.text = LocalisationSingleton.GetStringForId(2).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.SomethingMore)
        {
            text.text = LocalisationSingleton.GetStringForId(9).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.Colors)
        {
            text.text = LocalisationSingleton.GetStringForId(3).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.Development)
        {
            text.text = LocalisationSingleton.GetStringForId(8).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.Movements)
        {
            text.text = LocalisationSingleton.GetStringForId(4).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.Mixed)
        {
            text.text = LocalisationSingleton.GetStringForId(9).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.Shapes)
        {
            text.text = LocalisationSingleton.GetStringForId(5).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.Sizes)
        {
            text.text = LocalisationSingleton.GetStringForId(1).ToUpper();
        }
    }
}
