using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonLevelSelect : UIButton
{
    public int levelValue = 0;
    public Text percentage;
    public Text levelValueText;
    public Image fillImageFull;
    public Image background;

    protected float currentPercentage = 0.0f;
    protected float targetPercentage = 1.0f;

    public override void Start()
    {
        base.Start();
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
        EventManager.StartListening(EventManager.OnApplicationDataChanged, ReloadPercentage);
        currentPercentage = 0.1f;
        ReloadPercentage();
    }

    public void OnDisable()
    {
        EventManager.StopListening(EventManager.OnApplicationDataChanged, ReloadPercentage);
    }

    public void Update()
    {
        if (!isActiveAndEnabled)
        {
            return;
        }

        if (currentPercentage != targetPercentage)
        {
            currentPercentage = Mathf.Min(currentPercentage + (Time.deltaTime * 0.5f), targetPercentage);

            if (percentage)
            {
                percentage.text = ((int)(Mathf.Round(currentPercentage * 100.0f))).ToString() + "%";
            }
            if (fillImageFull)
            {
                fillImageFull.fillAmount = currentPercentage;
            }
        }

        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, MainManager.GetCurrentLevel() == levelValue ? Vector3.one * 1.0f : Vector3.one * 0.7f, Time.deltaTime * 5.0f);
    }

    protected override void OnButtonClick()
    {
        if(MainManager.GetCurrentScreen() != EGameScreen.Board)
        {
            base.OnButtonClick();
            MainManager.SetCurrentLevel(levelValue);
        }
    }

    protected void ReloadPercentage()
    {
        targetPercentage = MainManager.GetProgressPercentageAtLevel(levelValue);
        gameObject.transform.localScale = MainManager.GetCurrentLevel() == levelValue ? Vector3.one * 1.0f : Vector3.one * 0.7f;
    }
}
