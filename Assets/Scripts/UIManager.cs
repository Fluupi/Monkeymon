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

    [SerializeField] private AudioSource _ambiantSource;
    [SerializeField] private AudioClip _menuMusic;
    [SerializeField] private AudioClip _gameMusic;

    private void Start()
    {
        interactionPanel.gameObject.SetActive(false);
        _startMenu.SetActive(true);
        tutoPanel.SetActive(false);
        winPanel.SetActive(false);
        loosePanel.SetActive(false);
    }

    public void ShowInteraction(Monkenemy monkenemy, InteractionParameters interactionParameters)
    {
        interactionPanel.Generate(monkenemy, interactionParameters);
        interactionPanel.gameObject.SetActive(true);
        _ambiantSource.Pause();
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
        tutoPanel.SetActive(false);
        GameManager.Instance.UnFreeze();
        _ambiantSource.clip = _gameMusic;
        _ambiantSource.Play();
    }

    public void HideInteractionPanel()
    {
        interactionPanel.gameObject.SetActive(false);
        _ambiantSource.Pause();
    }

    public void UpdateBanana()
    {
        _textMeshPro.text = GameManager.Instance.Banana.ToString();
    }
}
