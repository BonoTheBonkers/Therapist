using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SequencesConfig", menuName = "Therapist/Singletons/SequencesConfig", order = 1)]
public class SequencesConfig : SingletonScriptableObject<SequencesConfig>
{
    public List<Sequence> sequences = new List<Sequence>();
}
