using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISliderSettings : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    public Sprite buttonOnIcon;
    public Sprite buttonOffIcon;
    public Image iconImage;
    public ESettingsSliderType settingsSliderType;
    protected Text text;
    protected Slider slider;
    protected Button button;

	void Start ()
    {
        text = GetComponentInChildren<Text>();
        slider = GetComponentInChildren<Slider>();
        if (slider)
        {
            slider.onValueChanged.AddListener(OnValueChanged);
        }
        button = GetComponentInChildren<Button>();
        if (button)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        ReloadProperties();
    }

    public void OnEnable()
    {
        EventManager.StartListening(EventManager.OnApplicationDataLoaded, ReloadProperties);
        EventManager.StartListening(EventManager.OnApplicationDataChanged, ReloadProperties);
    }

    public void OnDisable()
    {
        EventManager.StopListening(EventManager.OnApplicationDataLoaded, ReloadProperties);
        EventManager.StopListening(EventManager.OnApplicationDataChanged, ReloadProperties);
    }

    protected void ReloadProperties()
    {
        if(slider)
        {
            if (settingsSliderType == ESettingsSliderType.Music)
            {
                slider.value = MainManager.Instance.applicationData.applicationSettings.audioSettings.musicVolume;
                if(button)
                {
                    iconImage.sprite = MainManager.Instance.applicationData.applicationSettings.audioSettings.isMusicMuted ? buttonOffIcon : buttonOnIcon;
                }
            }
            else if (settingsSliderType == ESettingsSliderType.Sounds)
            {
                slider.value = MainManager.Instance.applicationData.applicationSettings.audioSettings.soundsVolume;
                if (button)
                {
                    iconImage.sprite = MainManager.Instance.applicationData.applicationSettings.audioSettings.isSoundsMuted ? buttonOffIcon : buttonOnIcon;
                }
            }
            else if (settingsSliderType == ESettingsSliderType.VideoQuality)
            {
                //@TODO
            }
        }
    }

    protected void OnValueChanged(float inValue)
    {
        if (settingsSliderType == ESettingsSliderType.Music)
        {
            MainManager.Instance.applicationData.SetMusicVolume(inValue);
        }
        else if(settingsSliderType == ESettingsSliderType.Sounds)
        {
            MainManager.Instance.applicationData.SetSoundsVolume(inValue);
        }
        else if(settingsSliderType == ESettingsSliderType.VideoQuality)
        {
            //@TODO
        }
    }

    protected void OnButtonClick()
    {
        if (settingsSliderType == ESettingsSliderType.Music)
        {
            MainManager.Instance.applicationData.SetIsMusicMuted(!MainManager.Instance.applicationData.applicationSettings.audioSettings.isMusicMuted);
        }
        else if (settingsSliderType == ESettingsSliderType.Sounds)
        {
            MainManager.Instance.applicationData.SetIsSoundsMuted(!MainManager.Instance.applicationData.applicationSettings.audioSettings.isSoundsMuted);
        }
        else if (settingsSliderType == ESettingsSliderType.VideoQuality)
        {
            //@TODO
        }
        EventManager.TriggerEvent(EventManager.OnButtonClicked);
    }

    protected void OnSliderPointer()
    {
        EventManager.TriggerEvent(EventManager.OnButtonClicked);
    }

    public void OnBeginDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        OnSliderPointer();
    }

    public void OnEndDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        OnSliderPointer();
    }
}
