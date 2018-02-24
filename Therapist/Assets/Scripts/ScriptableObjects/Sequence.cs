using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sequence", menuName = "Therapist/Sequence", order = 1)]
public class Sequence : ScriptableObject
{
    [Tooltip("Title of this sequence to be used on top under logo of game")]
    public string title = "Sequence";
    [Tooltip("Attributes that describes this sequence")]
    public List<EAttribute> attributes;
    [Tooltip("Contraindications that may be a problem in this sequence")]
    public List<EContraindications> contraindications;
    [Tooltip("Difficulty of this sequence")]
    public EDifficulty difficulty = EDifficulty.Medium;
    [Tooltip("Best adviced age range for player")]
    public Vector2 ageRange = new Vector2(1, 99);
    [Tooltip("List of images to be used in board of this sequence")]
    public List<Texture2D> images;
}
