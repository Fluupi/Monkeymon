using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Monkenemy : MonoBehaviour
{
    [SerializeField] private GameObject possibleInteractionIndicator;
    [SerializeField] public AnimatorController IlluSprite = null;

    public void OpenIndicator()
    {
        possibleInteractionIndicator.SetActive(true);
    }

    public void CloseIndicator()
    {
        possibleInteractionIndicator.SetActive(false);
    }
}
