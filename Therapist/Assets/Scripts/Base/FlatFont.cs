using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlatFont : MonoBehaviour
{
    /** VARIABLES */

    /* Public variables - START */

    public int localisationId = -1;

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

    void OnEnable()
    {
        ApplyLanguage();
        ApplyFont();
    }

    void OnValidate()
    {
        ApplyLanguage();
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

    public void ApplyLanguage()
    {
        if(localisationId < 0)
        {
            return;
        }

        if (GetComponent<Text>())
        {
            GetComponent<Text>().text = LocalisationSingleton.GetStringForId(localisationId).ToUpper();
        }
    }
}
