using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonRevertApplicationDataToDefault : MonoBehaviour {

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
        MainManager.Instance.applicationData = DefaultApplicationData.Instance.defaultApplicationData;
        EventManager.TriggerEvent(EventManager.OnApplicationDataChanged);
        MainManager.SetCurrentScreen(EGameScreen.MainMenu);
    }
}
