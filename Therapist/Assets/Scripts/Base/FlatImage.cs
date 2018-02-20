using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class FlatImage : MonoBehaviour
{
    /** VARIABLES */

    /* Public variables - START */

    [SerializeField]
    private EFlatColor _flatColor;
    public EFlatColor flatColor
    {
        get
        {
            return _flatColor;
        }
        set
        {
            Debug.Log("aasd");
            _flatColor = flatColor;
        }
    }
    public bool isShadowed = false;
    /* Public variables - END */

    public void Awake()
    {
    }

    void OnValidate()
    {
        if(Application.isPlaying)
        {
            return;
        }

        ApplyColor();
    }

    public void ApplyColor()
    {

        Color newColor = ColorsSingleton.GetColorFromFlat(flatColor, isShadowed);
        if (GetComponent<Image>())
        {
            GetComponent<Image>().color = newColor;
        }
        if (GetComponent<Text>())
        {
            GetComponent<Text>().color = newColor;
        }
    }
}
