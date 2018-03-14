using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSingleton : SingletonManager<SettingsSingleton>
{
    public void Start()
    {
        ReadLanguageFromSave();
        EventManager.StartListening(EventManager.OnApplicationDataLoaded, ReadLanguageFromSave);
    }

    protected void ReadLanguageFromSave()
    {
        if (MainManager.GetCurrentUser() != null)
        {
            SetLanguage(MainManager.Instance.applicationData.userData.language);
        }
    }

    public static ELanguage GetLanguage()
    {
        return MainManager.Instance.applicationData.userData.language;
    }

    public static void SetLanguage(ELanguage inLanguage)
    {
        if(MainManager.GetCurrentUser() != null)
        {
            MainManager.Instance.applicationData.SetLanguage(inLanguage);
        }
        EventManager.TriggerEvent(EventManager.OnLanguageChanged);
    }

    public static List<EContraindications> GetContraindications()
    {
        return MainManager.Instance.applicationData.userData.currentPlayer.currentContraindications;
    }

    public static void SetContraindications(List<EContraindications> inContraindications)
    {
        MainManager.Instance.applicationData.SetCurrentPlayerContraindications(inContraindications);
    }
}
