using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonUserSelect : MonoBehaviour
{
    public Image avatarImage;

    public Button selectButton;
    public Button changeNameButton;
    public Button deleteButton;
    public Button shareButton;
    public Button resetProgressButton;

    protected Text text;
    protected PlayerData playerData;
    // Use this for initialization

    public void InitializePlayerButton(PlayerData inPlayerData)
    {
        if (inPlayerData == null)
        {
            return;
        }

        playerData = inPlayerData;

        text = GetComponentInChildren<Text>();

        if (selectButton)
        {
            selectButton.onClick.AddListener(OnSelectButtonClick);
        }
        if (changeNameButton)
        {
            changeNameButton.onClick.AddListener(OnChangeNameButtonClick);
        }
        if (deleteButton)
        {
            deleteButton.onClick.AddListener(OnDeleteButtonClick);
        }
        if (shareButton)
        {
            shareButton.onClick.AddListener(OnShareButtonClick);
        }
        if (resetProgressButton)
        {
            resetProgressButton.onClick.AddListener(OnResetButtonClick);
        }

        if (playerData != null)
        {
            avatarImage.sprite = playerData.personalData.avatarSprite != null ? playerData.personalData.avatarSprite : PrefabsConfig.GetDefaultAvatarSprite();
            text.text = playerData.personalData.firstName.ToUpper() + " " + playerData.personalData.surName.ToUpper();
        }
    }

    void OnEnable()
    {
        EventManager.StartListening("OnPlayersListChanged", OnPlayerChanged);
    }

    void OnDisable()
    {
        EventManager.StopListening("OnPlayersListChanged", OnPlayerChanged);
    }

    protected void OnSelectButtonClick()
    {
        MainManager.SetCurrentPlayer(playerData);
        UIManager.SetPlayersListActive(false);
    }

    protected void OnPlayerChanged()
    {
        InitializePlayerButton(playerData);
    }

    protected void OnChangeNameButtonClick()
    {

    }
    protected void OnDeleteButtonClick()
    {
        MainManager.DeletePlayer(playerData);
    }
    protected void OnShareButtonClick()
    {

    }
    protected void OnResetButtonClick()
    {

    }
}
