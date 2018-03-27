using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class FlatImage : MonoBehaviour
{
    /** VARIABLES */

    /* Public variables - START */
    
    public EFlatColor flatColor;
    public bool isShadowed = false;

    public EThemePart themePart = EThemePart.None;
    /* Public variables - END */

    /* Protected variables - START */

    protected Image image;
    protected Text text;

    protected Color previousColor = Color.white;
    protected Color targetColor = Color.white;
    float currentLerpTime = 0.0f;

    /* Protected variables - END */

    public void Start()
    {
    }

    public void Update()
    {
        if(currentLerpTime > 0.0f)
        {
            currentLerpTime = Mathf.Max(currentLerpTime - (Time.deltaTime * 1.2f), 0.0f);
            ApplyColor(Color.Lerp(targetColor, previousColor, currentLerpTime));
        }
    }

    public Image GetImage()
    {
        if(!image)
        {
            image = GetComponent<Image>();
        }

        return image;
    }

    public Text GetText()
    {
        if (!text)
        {
            text = GetComponent<Text>();
        }

        return text;
    }

    public void OnEnable()
    {
        if(themePart != EThemePart.None)
        {
            EventManager.StartListening(EventManager.OnCurrentThemeColorChanged, ReadColor);
            ForceColorForLevel();
        }
    }
    public void OnDisable()
    {
        if (themePart != EThemePart.None)
        {
           EventManager.StopListening(EventManager.OnCurrentThemeColorChanged, ReadColor);
        }
    }

    protected void ReadColor()
    {
        currentLerpTime = 1.0f;
        previousColor = GetImage() ? GetImage().color : (GetText() ? GetText().color : Color.white);
        targetColor = ColorsSingleton.GetColorFromTheme(MainManager.currentThemeColor, themePart);
    }

    protected void ForceColorForLevel()
    {
        ReadColor();
        currentLerpTime = 0.0f;
        ApplyColor(targetColor);
    }

    void OnValidate()
    {
        if(Application.isPlaying)
        {
            return;
        }

        ApplyFlatColor();
    }

    public void ApplyColor(Color inColor)
    {
        if (GetImage())
        {
            GetImage().color = inColor;
        }
        if (GetText())
        {
            GetText().color = inColor;
        }
    }

    public void ApplyFlatColor()
    {
        if(themePart != EThemePart.None)
        {
            ForceColorForLevel();
        }
        else
        {
            ApplyColor(ColorsSingleton.GetColorFromFlat(flatColor, isShadowed));
        }
    }
}
