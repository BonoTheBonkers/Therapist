using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TokenController : MonoBehaviour
{
    protected ETokenPlaceType tokenPlaceType = ETokenPlaceType.None;
    int value = -1;
    [HideInInspector]
    public TokenPlaceController targetTokenPlace;
    [HideInInspector]
    public PointerEventData currentPointerEventData;
    public Image backgroundImage;
    public Image iconImage;
    [HideInInspector]
    public EAttribute attribute;

    public void Update()
    {
        MoveToTargetTokenPlace();
    }

    public void SetupToken(int inValue, Sprite inImage, TokenPlaceController inTargetTokenPlace, ETokenPlaceType inTokenPlaceType, EAttribute inAttribute, int maxSequenceValue)
    {
        value = inValue;
        iconImage.sprite = inImage;
        targetTokenPlace = inTargetTokenPlace;
        tokenPlaceType = inTokenPlaceType;
        attribute = inAttribute;
        if(attribute == EAttribute.Sizes && maxSequenceValue > 0)
        {
            iconImage.transform.localScale = Vector3.one * ((0.4f) + (0.6f * ((float)value / (float)maxSequenceValue)));
        }
        else
        {
            iconImage.transform.localScale = Vector3.one;
        }
    }

    public void TrySetTargetTokenPlace(TokenPlaceController newTargetTokenPlace)
    {
        if(newTargetTokenPlace == null)
        {
            return;
        }

        if (newTargetTokenPlace.GetValue() == value)
        {
            if (newTargetTokenPlace.GetTokenPlaceType() == ETokenPlaceType.CurrentSequence && tokenPlaceType == ETokenPlaceType.CurrentTokens)
            {
                targetTokenPlace = newTargetTokenPlace;
                tokenPlaceType = ETokenPlaceType.CurrentSequence;
                EventManager.TriggerEvent(EventManager.OnTargetTokenPlaceChanged);
            }
        }
    }

    protected void MoveToTargetTokenPlace()
    {
        if(targetTokenPlace == null)
        {
            return;
        }

        if(!IsTokenInFinalPlace() && currentPointerEventData != null)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, currentPointerEventData.position, Time.deltaTime * 550.0f);
        }
        else
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetTokenPlace.gameObject.transform.position, Time.deltaTime * 5.0f);
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, targetTokenPlace.gameObject.transform.parent.transform.localScale, Time.deltaTime * 5.0f);
        }
    }

    public bool IsTokenInFinalPlace()
    {
        if(targetTokenPlace != null)
        {
            if(targetTokenPlace.GetTokenPlaceType() == ETokenPlaceType.CurrentTokens)
            {
                return false;
            }
            else if(targetTokenPlace.GetTokenPlaceType() == ETokenPlaceType.ExampleSequence)
            {
                return true;
            }
            else if(targetTokenPlace.GetTokenPlaceType() == ETokenPlaceType.CurrentSequence)
            {
                if(targetTokenPlace.GetValue() == value)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void OnTokenBeginDrag(PointerEventData eventData)
    {
        currentPointerEventData = eventData;
    }

    public void OnTokenEndDrag(PointerEventData eventData)
    {
        currentPointerEventData = null;
    }
}
