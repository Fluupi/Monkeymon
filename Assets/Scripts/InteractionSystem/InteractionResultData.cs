using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/InteractionResultData", fileName = "InteractionResultData")]
public class InteractionResultData : ScriptableObject
{
    public AudioClip Sound;
    public Sprite Illustration;
}
