using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonUser : UIButton
{
    public Image avatarImage;
    protected Text text;
    public int addNewUserTextId = -1;

    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        UIManager.SetPlayersListActive(true);
        EventManager.TriggerEvent(EventManager.OnOptionScreenOpened);
    }

    public override void Start()
    {
        base.Start();
        text = GetComponentInChildren<Text>();
        OnPlayerChanged();
    }

    void OnEnable()
    {
        EventManager.StartListening(EventManager.OnPlayerChanged, OnPlayerChanged);
    }

    void OnDisable()
    {
        EventManager.StopListening(EventManager.OnPlayerChanged, OnPlayerChanged);
    }

    protected void OnPlayerChanged()
    {
        PlayerData playerData = MainManager.GetCurrentPlayer();
        if(playerData != null)
        {
            //avatarImage.sprite = playerData.personalData.avatarSprite != null ? playerData.personalData.avatarSprite : PrefabsConfig.GetDefaultAvatarSprite();
            text.text = playerData.personalData.firstName.ToUpper() + " " + playerData.personalData.surName.ToUpper();
        }
        else
        {
            avatarImage.sprite = PrefabsConfig.GetMissingAvatarSprite();
            text.text = LocalisationSingleton.GetStringForId(addNewUserTextId);
        }
    }
}
