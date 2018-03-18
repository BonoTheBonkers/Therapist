using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenController : MonoBehaviour
{

    public AnimationCurve alphaCurve;
    public int idCorrent;
    public int idCategoryFinished;
    public int idLevelFinished;
    private float currentTime = 0.0f;
    private float targetTime = 2.0f;
    private bool shouldBeActive = false;

    private CanvasGroup canvasGroup;

    void OnEnable()
    {
        GetCanvasGroup().alpha = 0.0f;
        GetCanvasGroup().blocksRaycasts = false;
        EventManager.StartListening(EventManager.OnCorrectAnswer, OnCorrectAnswer);
        EventManager.StartListening(EventManager.OnCurrentScreenChanged, OnCurrentScreenChanged);
        EventManager.StartListening(EventManager.OnConfirmScreenShowed, OnCurrentScreenChanged);
    }
    void OnDisable()
    {
        EventManager.StopListening(EventManager.OnCorrectAnswer, OnCorrectAnswer);
        EventManager.StopListening(EventManager.OnCurrentScreenChanged, OnCurrentScreenChanged);
        EventManager.StopListening(EventManager.OnConfirmScreenShowed, OnCurrentScreenChanged);
    }

    public CanvasGroup GetCanvasGroup()
    {
        if(canvasGroup == null)
        {
            canvasGroup = GetComponentInParent<CanvasGroup>();
        }

        return canvasGroup;
    }

    public void OnCorrectAnswer()
    {
        if (GetCanvasGroup() == null)
        {
            return;
        }

        currentTime = 0.0f;
        GetCanvasGroup().blocksRaycasts = true;
        shouldBeActive = true;
    }

    public void OnCurrentScreenChanged()
    {
        if(shouldBeActive)
        {
            MainManager.OnWin();
        }
        HideScreen(true);
    }

    protected void HideScreen(bool IsForced)
    {
        GetCanvasGroup().alpha = 0.0f;
        GetCanvasGroup().blocksRaycasts = false;
        shouldBeActive = false;
        if(!IsForced)
        {
            MainManager.OnWin();
        }
    } 

	void Update ()
    {
        if(!shouldBeActive || GetCanvasGroup() == null)
        {
            return;
        }

        currentTime = Mathf.Min(currentTime + Time.deltaTime, targetTime);
        if(currentTime >= targetTime)
        {
            HideScreen(false);
        }
        else
        {
            GetCanvasGroup().alpha = alphaCurve.Evaluate(currentTime / targetTime);
        }
	}
}
