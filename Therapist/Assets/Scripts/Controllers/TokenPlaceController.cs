using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenPlaceController : MonoBehaviour
{
    protected ETokenPlaceType tokenPlaceType = ETokenPlaceType.None;
    protected int value = -1;
    public Image backgroundImage;

    public void SetupTokenPlace(int inValue, ETokenPlaceType inTokenPlaceType)
    {
        value = inValue;
        tokenPlaceType = inTokenPlaceType;
    }
}
