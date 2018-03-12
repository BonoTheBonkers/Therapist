using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonAddNewPlayerButton_01 : MonoBehaviour
{
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
        UIManager.SetNewPlayerScreenActive(true);
        UIManager.SetPlayersListActive(false);
    }
}
