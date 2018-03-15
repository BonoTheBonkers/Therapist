using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonCreateNewPlayerButton_01 : UIButton
{
    protected UINewPlayerController newPlayerController;

    public override void Start()
    {
        base.Start();
        newPlayerController = GetComponentInParent<UINewPlayerController>();
    }

    protected override void OnButtonClick()
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
