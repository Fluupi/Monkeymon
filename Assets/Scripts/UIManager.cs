using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private InteractionPanel interactionPanel = null;
    [SerializeField] private GameObject tutoPanel = null;
    [SerializeField] private GameObject winPanel = null;
    [SerializeField] private GameObject loosePanel = null;
    [SerializeField] private TextMeshProUGUI _textMeshPro = null;
    [SerializeField] private GameObject _startMenu = null;

    private void Start()
    {
        HideInteractionPanel();
        _startMenu.SetActive(true);
        tutoPanel.SetActive(false);
        winPanel.SetActive(false);
        loosePanel.SetActive(false);
    }

    public void ShowInteraction(Monkenemy monkenemy, InteractionParameters interactionParameters)
    {
        interactionPanel.Generate(monkenemy, interactionParameters);
        interactionPanel.gameObject.SetActive(true);
    }

    public void ShowTuto()
    {
        tutoPanel.SetActive(true);
        GameManager.Instance.Freeze();
    }

    public void ShowWin(int bananaCount)
    {
        winPanel.SetActive(true);
        GameManager.Instance.Freeze();
    }

    public void ShowLoose(int bananaCount)
    {
        loosePanel.SetActive(true);
        GameManager.Instance.Freeze();
    }

    public void HideTutoPanel()
    {
        tutoPanel.gameObject.SetActive(false);
        GameManager.Instance.UnFreeze();
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
