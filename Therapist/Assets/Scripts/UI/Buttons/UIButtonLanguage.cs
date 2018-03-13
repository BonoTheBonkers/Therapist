using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonLanguage : MonoBehaviour
{
    public Image flagImage;
    protected Button button;
    // Use this for initialization
    void Start ()
    {
        button = GetComponentInChildren<Button>();
        if (button)
        {
            button.onClick.AddListener(OnButtonClick);
        }

        OnLanguageChanged();
    }

    void OnEnable()
    {
        EventManager.StartListening(EventManager.OnLanguageChanged, OnLanguageChanged);
    }

    void OnDisable()
    {
        EventManager.StopListening(EventManager.OnLanguageChanged, OnLanguageChanged);
    }

    protected void OnButtonClick()
    {
        UIManager.SetLanguagesListActive(true);
        EventManager.TriggerEvent(EventManager.OnOptionScreenOpened);
    }

    protected void OnLanguageChanged()
    {
        flagImage.sprite = LocalisationSingleton.GetFlagForCurrentLanguage();
    }
}
