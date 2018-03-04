using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TokenPlaceController : MonoBehaviour, IDropHandler
{
    protected ETokenPlaceType tokenPlaceType = ETokenPlaceType.None;
    protected int value = -1;
    public Image backgroundImage;

    public void SetupTokenPlace(int inValue, ETokenPlaceType inTokenPlaceType)
    {
        value = inValue;
        tokenPlaceType = inTokenPlaceType;
    }

    public ETokenPlaceType GetTokenPlaceType()
    {
        return tokenPlaceType;
    }

    public int GetValue()
    {
        return value;
    }

    public void OnDrop(PointerEventData eventData)
    {
        TokenController currentToken = UIManager.Instance.currentlyDraggedGameObject != null ? UIManager.Instance.currentlyDraggedGameObject.GetComponentInParent<TokenController>() : null;
        if(currentToken != null)
        {
            foreach (GameObject current in eventData.hovered)
            {
                if (current.GetComponent<TokenPlaceController>() == this)
                {
                    currentToken.TrySetTargetTokenPlace(this);
                }
            }
        }
    }
}
