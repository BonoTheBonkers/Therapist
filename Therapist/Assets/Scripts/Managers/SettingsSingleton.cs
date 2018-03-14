using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSingleton : SingletonManager<SettingsSingleton>
{
    public ELanguage language = ELanguage.Polish;
    public List<EContraindications> currentContraindications;
    public ProfilesData profilesData;

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
        if(!Instance)
        {
            return ELanguage.English;
        }
        return Instance.language;
    }

    public static void SetLanguage(ELanguage inLanguage)
    {
        Instance.language = inLanguage;
        if(MainManager.GetCurrentUser() != null)
        {
            MainManager.Instance.applicationData.SetLanguage(inLanguage);
        }
        EventManager.TriggerEvent(EventManager.OnLanguageChanged);
    }

    public static List<EContraindications> GetContraindications()
    {
        return Instance.currentContraindications;
    }

    public static void SetContraindications(List<EContraindications> inContraindications)
    {
        Instance.currentContraindications = inContraindications;
        EventManager.TriggerEvent(EventManager.OnContraindicationsChanged);
    }
}
