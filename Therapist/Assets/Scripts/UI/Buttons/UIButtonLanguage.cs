using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonLanguage : MonoBehaviour
{
    protected Button button;
    // Use this for initialization
    void Start ()
    {
        button = GetComponentInChildren<Button>();
        if (button)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    protected void OnButtonClick()
    {
        UIManager.SetLanguagesListActive(true);
    }
}
