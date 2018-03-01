using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIButtonLanguageSelect : MonoBehaviour
{
    public ELanguage language = ELanguage.Polish;
    public Image flagImage;
    protected Button button;
    void Start ()
    {
        button = GetComponentInChildren<Button>();
        if (button)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        //         flagImage = GetComponentInChildren<Image>();
        //         if (flagImage)
        //         {
        //             Sprite languageFlag;
        //             if (LocalisationDatabase.Instance.languageFlags.TryGetValue(language, out languageFlag))
        //             {
        //                 flagImage.sprite = languageFlag;
        //             }
        //         }
    }
    
    protected void OnButtonClick()
    {
        SettingsSingleton.SetLanguage(language);
        UIManager.SetLanguagesListActive(false);
    }
}
