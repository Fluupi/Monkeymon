using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject interactionPanel;

    private void Start()
    {
        HideInteractionPanel();
    }

    public void ShowInteraction(Monkenemy monkenemy)
    {
        interactionPanel.SetActive(true);
    }

    public void HideInteractionPanel()
    {
        interactionPanel.SetActive(false);
    }
}
