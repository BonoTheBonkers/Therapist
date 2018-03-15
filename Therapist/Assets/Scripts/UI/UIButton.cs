using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    protected Button button;

    public virtual void Start()
    {
        button = GetComponentInChildren<Button>();
        if (button)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    protected virtual void OnButtonClick()
    {
        EventManager.TriggerEvent(EventManager.OnButtonClicked);
    }
}
