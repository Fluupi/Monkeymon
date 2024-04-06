using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/InteractionParameters", fileName = "InteractionParameters")]
public class InteractionParameters : ScriptableObject
{
    [SerializeField] public Vocalization Vocalization = null;

    [SerializeField] public AudioClip AudioClip = null; 

    [SerializeField] public Sprite AudioSprite = null; 
}
