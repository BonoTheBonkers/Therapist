using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LocalisationDatabase", menuName = "Therapist/Singletons/LocalisationDatabase", order = 1)]
public class LocalisationDatabase : SingletonScriptableObject<ColorsPalette>
{
    public bool reloadLocalisationDatabase = false;
    public static string csvDatabasePath = "Localisation Database - DB_localisation";

    [Tooltip("Databases for every language")]
    public static Dictionary<ELanguage, FLanguageDatabase> languages = new Dictionary<ELanguage, FLanguageDatabase>();

    void OnValidate()
    {
        if (Application.isPlaying)
        {
            return;
        }

        if(reloadLocalisationDatabase)
        {
            ReloadLocalisationDatabase();

            reloadLocalisationDatabase = false;
        }
        FlatImage[] flatImages = FindObjectsOfType(typeof(FlatImage)) as FlatImage[];
        foreach (FlatImage current in flatImages)
        {
            current.ApplyColor();
        }
    }

    public static void ReloadLocalisationDatabase()
    {
        for (int i = 0; i <= (int)ELanguage.Polish; ++i)
        {
            FLanguageDatabase languageDatabase;
            if (languages.TryGetValue((ELanguage)i, out languageDatabase))
            {
                languageDatabase.texts.Clear();
            }
            else
            {
                languages.Add((ELanguage)i, new FLanguageDatabase());
            }
        }
        string[] lines = LoadLines("CSV/" + csvDatabasePath);

        if (lines.Length > 1)
        {
            for (int i = 1; i < lines.Length; ++i)
            {
                string[] lineData = (lines[i].Trim()).Split(","[0]);
                lineData = ConvertCharToCharInStringArray(lineData, '|', ',');
                for(int j = 0; j < lineData.Length; ++j)
                {
                    FLanguageDatabase languageDatabase;
                    if(languages.TryGetValue((ELanguage)j, out languageDatabase))
                    {
                        languageDatabase.texts.Add(lineData[j]);
                    }
                }
                
            }
        }
        else
        {
            Debug.LogError("[Database]: Couldn't find LocalisationDatabase file: CSV/" + csvDatabasePath);
        }
    }

    private static string[] LoadLines(string path)
    {
        TextAsset fileData = (TextAsset)Resources.Load(path, typeof(TextAsset));
        if (fileData != null)
        {
            string[] lines = fileData.text.Split("\n"[0]);
            return lines;
        }
        else
        {
            Debug.LogError("[Database]: Cannot find " + path + " file.");
        }
        return null;
    }

    private static string[] ConvertCharToCharInStringArray(string[] InStringArray, char InChar, char OutChar)
    {
        string[] OutStringArray = InStringArray;
        for (int i = 0; i < OutStringArray.Length; ++i)
        {
            OutStringArray[i] = OutStringArray[i].Replace(InChar, OutChar);
        }

        return OutStringArray;
    }
}
