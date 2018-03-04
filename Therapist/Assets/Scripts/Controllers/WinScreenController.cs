using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenController : MonoBehaviour
{

    public AnimationCurve alphaCurve;
    private float currentTime = 0.0f;
    private float targetTime = 3.0f;
    private bool shouldBeActive = false;

    private CanvasGroup canvasGroup;

    void OnEnable()
    {
        GetCanvasGroup().alpha = 0.0f;
        GetCanvasGroup().blocksRaycasts = false;
        EventManager.StartListening("OnCorrectAnswer", OnCorrectAnswer);
    }
    void OnDisable()
    {
        EventManager.StopListening("OnCorrectAnswer", OnCorrectAnswer);
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

    protected void HideScreen()
    {
        GetCanvasGroup().alpha = 0.0f;
        GetCanvasGroup().blocksRaycasts = false;
        shouldBeActive = false;
        MainManager.OnWin();
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
            HideScreen();
        }
        else
        {
            GetCanvasGroup().alpha = alphaCurve.Evaluate(currentTime / targetTime);
        }
	}
}
