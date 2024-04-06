using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private InteractionPanel interactionPanel = null;

    private void Start()
    {
        HideInteractionPanel();
    }

    public void ShowInteraction(Monkenemy monkenemy, InteractionParameters interactionParameters)
    {
        interactionPanel.Generate(monkenemy, interactionParameters);
        interactionPanel.gameObject.SetActive(true);
    }

    public void HideInteractionPanel()
    {
        interactionPanel.gameObject.SetActive(false);
    }
}
