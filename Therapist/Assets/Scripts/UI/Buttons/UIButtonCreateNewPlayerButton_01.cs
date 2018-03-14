using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonCreateNewPlayerButton_01 : MonoBehaviour
{
    protected UINewPlayerController newPlayerController;
    protected Button button;

    public void Start()
    {
        button = GetComponentInChildren<Button>();
        if (button)
        {
            button.onClick.AddListener(OnButtonClick);
        }

        newPlayerController = GetComponentInParent<UINewPlayerController>();
    }

    protected void OnButtonClick()
    {
        MainManager.CreateNewPlayer(newPlayerController.firstNameField.text, newPlayerController.surNameField.text, int.Parse(newPlayerController.ageField.text));
        UIManager.SetNewPlayerScreenActive(false);
        if(MainManager.Instance.applicationData.userData.players.Count == 1)
        {
            MainManager.SetCurrentPlayer(MainManager.Instance.applicationData.userData.players[0]);
        }
        UIManager.SetPlayersListActive(MainManager.Instance.applicationData.userData.players.Count > 1);
    }
}
