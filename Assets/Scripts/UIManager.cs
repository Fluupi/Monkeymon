using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private InteractionPanel interactionPanel = null;
    [SerializeField] private TextMeshProUGUI _textMeshPro = null;
    [SerializeField] private GameObject _startMenu = null;

    private void Start()
    {
        HideInteractionPanel();
        _startMenu.SetActive(true);
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

    public void UpdateBanana()
    {
        _textMeshPro.text = GameManager.Instance.Banana.ToString();
    }
}
