using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonUser : MonoBehaviour
{
    public Image avatarImage;
    protected Button button;
    protected Text text;
    public int addNewUserTextId = -1;
    // Use this for initialization
    void Start()
    {
        button = GetComponentInChildren<Button>();
        if (button)
        {
            button.onClick.AddListener(OnButtonClick);
        }
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

    protected void OnButtonClick()
    {
        UIManager.SetPlayersListActive(true);
        EventManager.TriggerEvent(EventManager.OnOptionScreenOpened);
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
