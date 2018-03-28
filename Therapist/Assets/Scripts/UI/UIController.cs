using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [HideInInspector]
    public CanvasGroup canvasGroup;
    protected bool shouldBeActive = false;

    protected float ShowSpeed = 1.5f;
    protected float HideSpeed = 1.5f;

    public virtual void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0.0f;
        }

        shouldBeActive = gameObject.activeInHierarchy;
    }

    public virtual void Update()
    {
        if(canvasGroup != null)
        {
            if(shouldBeActive)
            {
                canvasGroup.alpha = Mathf.Min(canvasGroup.alpha + (Time.deltaTime * ShowSpeed), 1.0f);
            }
            else
            {
                canvasGroup.alpha = Mathf.Max(canvasGroup.alpha - (Time.deltaTime * HideSpeed), 0.0f);
                if(canvasGroup.alpha <= 0.0f)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    public virtual void SetUIActive(bool value)
    {
        if(value)
        {
            gameObject.SetActive(true);
            shouldBeActive = true;
        }
        else
        {
            shouldBeActive = false;
        }
    }

    public virtual void SetUIActiveInstant(bool value)
    {
        SetUIActive(value);
        if (canvasGroup != null)
        {
            if (value)
            {
                canvasGroup.alpha = 1.0f;
            }
            else
            {
                canvasGroup.alpha = 0.0f;
            }
        }
    }

    public virtual bool IsUIActive()
    {
        return gameObject.activeInHierarchy;
    }

    public virtual void OnEnable()
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0.0f;
        }
    }

    public virtual void OnDisable()
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0.0f;
        }
    }
}
