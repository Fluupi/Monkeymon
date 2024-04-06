using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Vocalizations", fileName = "Vocalization")]
public class Vocalization : ScriptableObject
{
    public AudioClip Sound;
    public VocalizationLength Length;
    public VocalizationTessiture Tessiture;
    public InteractionAnswer AwaitedAnswer;
}

public enum VocalizationLength
{
    Short,
    Long,
    Multiple
}

public enum VocalizationTessiture
{
    Acute,
    Low,
    Both
}