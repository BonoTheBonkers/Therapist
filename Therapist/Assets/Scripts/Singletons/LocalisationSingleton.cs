using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LocalisationSingleton : SingletonMonoBehaviour<LocalisationSingleton>
{
    public void Start()
    {
        EventManager.StartListening("OnLanguageChanged", OnLanguageChanged);
    }

    public static string GetStringForIdAndLanguage(ELanguage inLanguage, int id)
    {
        FLanguageDatabase languageDatabase;
        if (LocalisationDatabase.languages.TryGetValue(inLanguage, out languageDatabase))
        {
            if(languageDatabase.texts.Count > id)
            {
                return languageDatabase.texts[id];
            }
        }
        return GetUnknownStringForLanguage(inLanguage);
    }

    public static string GetStringForId(int id)
    {
        return GetStringForIdAndLanguage(SettingsSingleton.GetLanguage(), id);
    }

    public static string GetUnknownStringForLanguage(ELanguage inLanguage)
    {
        if(inLanguage == ELanguage.English)
        {
            return "Text unknown";
        }
        else if (inLanguage == ELanguage.Spanish)
        {
            return "Texto desconocido";
        }
        else if (inLanguage == ELanguage.SimplifiedChinese)
        {
            return "文字未知";
        }
        else if (inLanguage == ELanguage.Japanese)
        {
            return "テキスト不明";
        }
        else if (inLanguage == ELanguage.Korean)
        {
            return "문자를 알 수 없음";
        }
        else if (inLanguage == ELanguage.French)
        {
            return "Texte inconnu";
        }
        else if (inLanguage == ELanguage.German)
        {
            return "Text unbekannt";
        }
        else if (inLanguage == ELanguage.Italian)
        {
            return "Testo sconosciuto";
        }
        else if (inLanguage == ELanguage.Portuguese)
        {
            return "Texto desconhecido";
        }
        else if (inLanguage == ELanguage.Arabic)
        {
            return "نص غير معروف";
        }
        else if (inLanguage == ELanguage.Russian)
        {
            return "Текст неизвестен";
        }
        else if (inLanguage == ELanguage.Hindi)
        {
            return "अज्ञात पाठ";
        }
        else if (inLanguage == ELanguage.Swedish)
        {
            return "अज्ञात पाठ";
        }
        else if (inLanguage == ELanguage.Polish)
        {
            return "Tekst nieznany";
        }

        return "Text and language unknown";
    }

    void OnValidate()
    {
        Debug.Log("TEST");
        if (Application.isPlaying)
        {
            return;
        }

        OnLanguageChanged();
    }

    void OnLanguageChanged()
    {
        FlatImage[] flatImages = FindObjectsOfType(typeof(FlatImage)) as FlatImage[];
        foreach (FlatImage current in flatImages)
        {
            current.ApplyColor();
        }
    }
}
