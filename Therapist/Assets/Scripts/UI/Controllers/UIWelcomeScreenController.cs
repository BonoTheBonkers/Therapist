using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWelcomeScreenController : UIController
{
    public Text loginText;
    public List<GameObject> notLoggedInObjects;

    public float currentTime = 0.0f;
    protected bool IsAskingAboutLogIn = false;


    public override void Start()
    {
        ShowSpeed = 0.2f;
        HideSpeed = 1.1f;
        base.Start();

        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1.0f;
        }

        shouldBeActive = false;
        EventManager.StartListening(EventManager.OnAccountLogIn, UpdateLogin);
        EventManager.StartListening(EventManager.OnAccountLogOut, UpdateLogin);
    }

    public override void Update()
    {
        if(!IsAskingAboutLogIn)
        {
            if (currentTime > 1.6f)
            {
                base.Update();
            }
            else
            {
                currentTime += Time.deltaTime;
            }
        }
    }

    public void UpdateLogin()
    {
        if (loginText != null && MainManager.Instance != null)
        {
            loginText.text = MainManager.Instance.applicationData.GetCurrentLogin();
            if(loginText.text == "")
            {
                loginText.text = LocalisationSingleton.GetStringForId(61);
                IsAskingAboutLogIn = true;
                foreach(GameObject current in notLoggedInObjects)
                {
                    current.SetActive(IsAskingAboutLogIn);
                }
            }
        }
    }

    public override void SetUIActive(bool value)
    {
        currentTime = 0.0f;
        base.SetUIActive(value);
        shouldBeActive = false;
        if(!value)
        {
            IsAskingAboutLogIn = false;
            currentTime = 1.6f;
        }
    }
}
