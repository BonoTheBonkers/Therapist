using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlatFont : MonoBehaviour
{
    /** VARIABLES */

    /* Public variables - START */

    [SerializeField]
    private EFlatFont _flatFont;
    public EFlatFont flatFont
    {
        get
        {
            return _flatFont;
        }
        set
        {
            _flatFont = flatFont;
        }
    }

    /* Public variables - END */

    void OnValidate()
    {
        if (Application.isPlaying)
        {
            return;
        }

        ApplyFont();
    }

    public void ApplyFont()
    {

        Font newFont = FontsSingleton.GetFontFromFlat(flatFont);
        if (GetComponent<Text>())
        {
            GetComponent<Text>().font = newFont;
        }
    }
}
