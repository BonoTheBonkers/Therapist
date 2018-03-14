using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : SingletonManager<SaveManager>
{
	void OnEnable ()
    {
        LoadData();
        EventManager.StartListening(EventManager.OnApplicationDataChanged, SaveData);
	}
	
	void OnDisable()
    {
        EventManager.StopListening(EventManager.OnApplicationDataChanged, SaveData);
    }

    public static void LoadData()
    {
        if(Instance != null)
        {
            Instance.LoadDataPrivate();
        }
    }

    protected void LoadDataPrivate()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            MainManager.Instance.applicationData = (FApplicationData)bf.Deserialize(file);
            file.Close();
        }
    }

    public static void SaveData()
    {
        if (Instance != null)
        {
            Instance.SaveDataPrivate();
        }
    }

    protected void SaveDataPrivate()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, MainManager.Instance.applicationData);
        file.Close();
    }
}
