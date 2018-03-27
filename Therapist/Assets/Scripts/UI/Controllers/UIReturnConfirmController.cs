using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIReturnConfirmController : UIController
{
    [HideInInspector]
    public EReturnConfirmType returnConfirmType;
    public int returnToAttributesTextId = -1;
    public int returnToReturnToMainMenuTextId = -1;
    public int returnQuitApplicationTextId = -1;
    public int returnResetApllicationTextId = -1;

    public override void Start()
    {
        base.Start();
        ShowSpeed = 10.0f;
        HideSpeed = 4.0f;
    }
    public void ShowConfirmScreen(EReturnConfirmType inReturnConfirmType)
    {
        FlatFont flatFont = GetComponentInChildren<FlatFont>();
        if(flatFont)
        {
            if(inReturnConfirmType == EReturnConfirmType.QuitApplication)
            {
                flatFont.localisationId = returnQuitApplicationTextId;
            }
            else if(inReturnConfirmType == EReturnConfirmType.ResetApllication)
            {
                flatFont.localisationId = returnResetApllicationTextId;
            }
            else if (inReturnConfirmType == EReturnConfirmType.ReturnToAttributes)
            {
                flatFont.localisationId = returnToAttributesTextId;
            }
            else if (inReturnConfirmType == EReturnConfirmType.ReturnToMainMenu)
            {
                flatFont.localisationId = returnToReturnToMainMenuTextId;
            }
        }
        returnConfirmType = inReturnConfirmType;
        SetUIActive(true);
        EventManager.TriggerEvent(EventManager.OnConfirmScreenShowed);
    }

    public void HideConfirmScreen()
    {
        SetUIActive(false);
    }
}
