using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonBoardInformationLevel : MonoBehaviour
{
    public Text valueText;

    protected Button button;
    // Use this for initialization

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
        EventManager.StartListening("OnCurrentLevelChanged", ReloadCurrentLevel);
        ReloadCurrentLevel();
    }

    public void OnDisable()
    {
        EventManager.StopListening("OnCurrentLevelChanged", ReloadCurrentLevel);
    }

    protected void OnButtonClick()
    {
    }

    protected void ReloadCurrentLevel()
    {
        valueText.text = (MainManager.GetCurrentLevel() + 1).ToString();
    }
}
