using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSingleton : SingletonManager<SettingsSingleton>
{
    public ELanguage language = ELanguage.Polish;
    public List<EContraindications> currentContraindications;

    public static ELanguage GetLanguage()
    {
        return Instance.language;
    }

    public static void SetLanguage(ELanguage inLanguage)
    {
        Instance.language = inLanguage;
        EventManager.TriggerEvent("OnLanguageChanged");
    }

    public static List<EContraindications> GetContraindications()
    {
        return Instance.currentContraindications;
    }

    public static void SetContraindications(List<EContraindications> inContraindications)
    {
        Instance.currentContraindications = inContraindications;
        EventManager.TriggerEvent("OnContraindicationsChanged");
    }
}
