using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonLevelSelect : MonoBehaviour
{
    public int levelValue = 0;
    public Text percentage;
    public Text levelValueText;
    public Image fillImageFull;
    public Image background;
    protected Button button;

    protected float currentPercentage = 0.0f;
    protected float targetPercentage = 1.0f;

    public void Start()
    {
        button = GetComponentInChildren<Button>();
        if (button)
        {
            button.onClick.AddListener(OnButtonClick);
        }

        if(levelValueText)
        {
            levelValueText.text = (levelValue + 1).ToString();
        }

        fillImageFull.gameObject.GetComponent<FlatImage>().flatColor = LevelsConfig.GetLevels()[levelValue].themeColor;
        fillImageFull.gameObject.GetComponent<FlatImage>().isShadowed = false;
        fillImageFull.gameObject.GetComponent<FlatImage>().ApplyFlatColor();

        background.gameObject.GetComponent<FlatImage>().flatColor = LevelsConfig.GetLevels()[levelValue].themeColor;
        background.gameObject.GetComponent<FlatImage>().isShadowed = true;
        background.gameObject.GetComponent<FlatImage>().ApplyFlatColor();
    }

    public void OnEnable()
    {
        ReloadPercentage();
    }

    public void OnDisable()
    {
    }

    public void Update()
    {
        if (!isActiveAndEnabled)
        {
            return;
        }

        if (currentPercentage != targetPercentage)
        {
            currentPercentage = Mathf.Min(currentPercentage + (Time.deltaTime * 0.6f), targetPercentage);
        }

        if (percentage)
        {
            percentage.text = ((int)(currentPercentage * 100.0f)).ToString() + "%";
        }
        if (fillImageFull)
        {
            fillImageFull.fillAmount = currentPercentage;
        }
        
        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, MainManager.GetCurrentLevel() == levelValue ? Vector3.one : Vector3.one * 0.85f, Time.deltaTime * 20.0f);
    }

    protected void OnButtonClick()
    {
        MainManager.SetCurrentLevel(levelValue);
        if(MainManager.GetCurrentScreen() == EGameScreen.Levels)
        {
            MainManager.SetCurrentScreen(EGameScreen.MainMenu);
        }
    }

    protected void ReloadPercentage()
    {
        currentPercentage = 0.0f;
        targetPercentage = MainManager.GetProgressPercentageAtLevel(levelValue);
        gameObject.transform.localScale = MainManager.GetCurrentLevel() == levelValue ? Vector3.one : Vector3.one * 0.85f;
    }
}
