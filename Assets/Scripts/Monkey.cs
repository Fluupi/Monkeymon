using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    [SerializeField] private GameObject possibleInteractionIndicator;

    public void OpenIndicator()
    {
        possibleInteractionIndicator.SetActive(true);
    }

    public void CloseIndicator()
    {
        possibleInteractionIndicator.SetActive(false);
    }
}
