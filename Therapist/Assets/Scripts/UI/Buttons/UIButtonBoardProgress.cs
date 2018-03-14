using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonBoardProgress : MonoBehaviour
{
    public Text percentage;
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

        fillImageFull.gameObject.GetComponent<FlatImage>().flatColor = LevelsConfig.GetLevels()[MainManager.GetCurrentLevel()].themeColor;
        fillImageFull.gameObject.GetComponent<FlatImage>().isShadowed = false;
        fillImageFull.gameObject.GetComponent<FlatImage>().ApplyFlatColor();

        background.gameObject.GetComponent<FlatImage>().flatColor = LevelsConfig.GetLevels()[MainManager.GetCurrentLevel()].themeColor;
        background.gameObject.GetComponent<FlatImage>().isShadowed = true;
        background.gameObject.GetComponent<FlatImage>().ApplyFlatColor();
    }

    public void OnEnable()
    {
        currentPercentage = 0.1f;
        targetPercentage = 0.0f;
        EventManager.StartListening(EventManager.OnCurrentProgressLevelChanged, ReloadPercentage);
    }

    public void OnDisable()
    {
        EventManager.StopListening(EventManager.OnCurrentProgressLevelChanged, ReloadPercentage);
    }

    public void Update()
    {
        if (!isActiveAndEnabled)
        {
            return;
        }

        if (currentPercentage != targetPercentage)
        {
            currentPercentage = Mathf.Min(currentPercentage + (Time.deltaTime * 0.2f), targetPercentage);

            if (percentage)
            {
                percentage.text = ((int)(Mathf.Round(currentPercentage * 100.0f))).ToString() + "%";
            }
            if (fillImageFull)
            {
                fillImageFull.fillAmount = currentPercentage;
            }
        }
    }

    protected void OnButtonClick()
    {

    }

    protected void ReloadPercentage()
    {
        currentPercentage = targetPercentage;
        targetPercentage = MainManager.GetCurrentProgressLevelPercentage();
    }
}
