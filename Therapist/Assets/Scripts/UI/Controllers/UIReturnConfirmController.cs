using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIReturnConfirmController : SingletonManager<UIReturnConfirmController>
{
    [HideInInspector]
    public EReturnConfirmType returnConfirmType;
    public int returnToAttributesTextId = -1;
    public int returnToReturnToMainMenuTextId = -1;
    public int returnQuitApplicationTextId = -1;
    public int returnResetApllicationTextId = -1;

    public static void ShowConfirmScreen(EReturnConfirmType inReturnConfirmType)
    {
        if(Instance)
        {
            Instance.ShowConfirmScreenPrivate(inReturnConfirmType);
        }
    }

    protected void ShowConfirmScreenPrivate(EReturnConfirmType inReturnConfirmType)
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
        Instance.gameObject.SetActive(true);
    }

    public static void HideConfirmScreen()
    {
        if (Instance)
        {
            Instance.HideConfirmScreenPrivate();
        }
    }

    protected void HideConfirmScreenPrivate()
    {
        Instance.gameObject.SetActive(false);
    }
}
