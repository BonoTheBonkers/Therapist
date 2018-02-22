using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sequence", menuName = "Therapist/Sequence", order = 1)]
public class Sequence : ScriptableObject
{
    public string title = "Sequence";
    public List<EAttribute> attributes;
    public List<EContraindications> contraindications;
    public EDifficulty difficulty = EDifficulty.Medium;
    public Vector2 ageRange = new Vector2(1, 99);
    public List<Texture2D> images;
}
