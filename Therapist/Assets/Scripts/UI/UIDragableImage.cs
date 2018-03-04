using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIDragableImage : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    protected TokenController tokenController;

    protected TokenController GetTokenController()
    {
        if (tokenController == null)
        {
            tokenController = GetComponentInParent<TokenController>();
        }

        return tokenController;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(GetTokenController())
        {
            GetTokenController().OnTokenBeginDrag(eventData);
            GetComponent<Image>().raycastTarget = false;
            UIManager.Instance.currentlyDraggedGameObject = gameObject;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (GetTokenController())
        {
            GetTokenController().OnTokenEndDrag(eventData);
            GetComponent<Image>().raycastTarget = true;
            if(UIManager.Instance.currentlyDraggedGameObject == gameObject)
            {
                UIManager.Instance.currentlyDraggedGameObject = null;
            }
        }
    }
}
