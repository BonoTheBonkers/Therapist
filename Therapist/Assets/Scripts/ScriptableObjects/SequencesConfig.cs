using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SequencesConfig", menuName = "Therapist/Singletons/SequencesConfig", order = 1)]
public class SequencesConfig : SingletonScriptableObject<SequencesConfig>
{
    [Tooltip("Button for reloading database")]
    public bool reloadSequencesDatabase = false;
    [Tooltip("List of all sequences to be used in project")]
    public List<Sequence> sequences = new List<Sequence>();

    [Tooltip("Database for sequences per attribute")]
    public static Dictionary<EAttribute, FSequencesDatabase> sequencesSorted = new Dictionary<EAttribute, FSequencesDatabase>();

    void OnValidate()
    {
        if (Application.isPlaying)
        {
            return;
        }

        if (reloadSequencesDatabase)
        {
            ReloadSequencesDatabase();

            reloadSequencesDatabase = false;
        }
    }

    public static void ReloadSequencesDatabase()
    {
        if (!Instance)
        {
            Debug.Log("SEQUENCES CONFIG: Couldn't reload sequences - no instance of class!");
            return;
        }

        for (int i = 0; i < (int)EAttribute.Max; ++i)
        {
            FSequencesDatabase sequencesDatabase;
            if (sequencesSorted.TryGetValue((EAttribute)i, out sequencesDatabase))
            {
                sequencesDatabase.sequences.Clear();
            }
            else
            {
                sequencesSorted.Add((EAttribute)i, new FSequencesDatabase());
            }
        }

        for (int i = 0; i < Instance.sequences.Count; ++i)
        {
            for (int j = 0; j < Instance.sequences[i].attributes.Count; ++j)
            {
                FSequencesDatabase sequencesDatabase;
                if (sequencesSorted.TryGetValue(Instance.sequences[i].attributes[j], out sequencesDatabase))
                {
                    sequencesDatabase.sequences.Add(Instance.sequences[i]);
                }
            }
        }

        string finalString = "Generated and sorted sequences: ";
        for (int i = 0; i < (int)EAttribute.Max; ++i)
        {
            FSequencesDatabase sequencesDatabase;
            if (sequencesSorted.TryGetValue((EAttribute)i, out sequencesDatabase))
            {
                finalString += (((EAttribute)i).ToString() + "-" + sequencesDatabase.sequences.Count + " | ");
            }
        }
        Debug.Log(finalString);
    }

    public static bool GetRandomSequence(EAttribute inAttribute, FBoardConfig inBoardConfig, out Sequence outSequence)
    {
        FSequencesDatabase sequencesDatabase;
        if(sequencesSorted.TryGetValue(inAttribute, out sequencesDatabase))
        {
            if(sequencesDatabase.sequences.Count > 0)
            {
                int randomSequence = Random.Range(0, sequencesDatabase.sequences.Count - 1);
                outSequence = sequencesDatabase.sequences[randomSequence];
                return true;
            }
            else
            {
                Debug.Log("SequenceConfig -  no sequences of " + inAttribute.ToString());
            }
        }

        Debug.Log("SequenceConfig - GetRandomSequence failed! " + inAttribute.ToString());
        outSequence = new Sequence();
        return false;
    }
}
