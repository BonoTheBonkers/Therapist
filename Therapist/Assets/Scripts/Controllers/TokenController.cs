using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenController : MonoBehaviour
{
    protected ETokenPlaceType tokenPlaceType = ETokenPlaceType.None;
    //int value = -1;
    public TokenPlaceController targetTokenPlace;
    public Image backgroundImage;
    public Image iconImage;

    public void Update()
    {
        MoveToTargetTokenPlace();
    }

    public void SetupToken(int inValue, Sprite inImage, TokenPlaceController inTargetTokenPlace, ETokenPlaceType inTokenPlaceType)
    {
        //value = inValue;
        iconImage.sprite = inImage;
        targetTokenPlace = inTargetTokenPlace;
        tokenPlaceType = inTokenPlaceType;
    }

    protected void MoveToTargetTokenPlace()
    {
        if(targetTokenPlace == null)
        {
            return;
        }

        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetTokenPlace.gameObject.transform.position, Time.deltaTime * 5.0f);
        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, targetTokenPlace.gameObject.transform.parent.transform.localScale, Time.deltaTime * 5.0f);
    }
}
