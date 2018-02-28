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
        image = GetComponent<Image>();
        text = GetComponent<Text>();
    }

    public void Update()
    {
        if(currentLerpTime > 0.0f)
        {
            currentLerpTime = Mathf.Max(currentLerpTime - Time.deltaTime, 0.0f);
            ApplyColor(Color.Lerp(targetColor, previousColor, currentLerpTime));
        }
    }

    public void OnEnable()
    {
        if(themePart != EThemePart.None)
        {
            EventManager.StartListening("OnCurrentLevelChanged", ReadColorForLevel);
            ReadColorForLevel();
            currentLerpTime = 0.0f;
            ApplyColor(targetColor);
        }
    }
    public void OnDisable()
    {
        if (themePart != EThemePart.None)
        {
           EventManager.StopListening("OnCurrentLevelChanged", ReadColorForLevel);
        }
    }

    protected void ReadColorForLevel()
    {
        currentLerpTime = 1.0f;
        previousColor = GetComponent<Image>() ? GetComponent<Image>().color : (GetComponent<Text>() ? GetComponent<Text>().color : Color.white);
        targetColor = ColorsSingleton.GetColorFromThemeForCurrentLevel(themePart);
    }

    protected void ForceColorForLevel()
    {
        ReadColorForLevel();
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
        if (image)
        {
            image.color = inColor;
        }
        if (text)
        {
            text.color = inColor;
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
