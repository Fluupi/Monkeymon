using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private InteractionPanel interactionPanel = null;
    [SerializeField] private Button interactionBaseButton = null;
    [SerializeField] private GameObject tutoPanel = null;
    [SerializeField] private Button tutoBaseButton = null;
    [SerializeField] private GameObject winPanel = null;
    [SerializeField] private Button winBaseButton = null;
    [SerializeField] private GameObject loosePanel = null;
    [SerializeField] private Button looseBaseButton = null;
    [SerializeField] private TextMeshProUGUI _bananaCounterText = null;
    [SerializeField] private TextMeshProUGUI _encounterCounterText = null;
    [SerializeField] private GameObject _startMenu = null;
    [SerializeField] private Button menuBaseButton = null;
    [SerializeField] private Image _hutImage = null;
    [SerializeField] private Image _hutArrow = null;

    [SerializeField] private AudioSource _ambiantSource;
    [SerializeField] private AudioClip _menuMusic;
    [SerializeField] private AudioClip _gameMusic;
    [SerializeField] private float _interactionMusicVolume = 0.1f;

    private void Start()
    {
        interactionPanel.gameObject.SetActive(false);
        _startMenu.SetActive(true);
        tutoPanel.SetActive(false);
        winPanel.SetActive(false);
        loosePanel.SetActive(false);
        menuBaseButton.Select();
        _hutImage.gameObject.SetActive(false);
        _hutArrow.gameObject.SetActive(false);
    }

    public void ShowInteraction(Monkenemy monkenemy, InteractionParameters interactionParameters)
    {
        interactionPanel.Generate(monkenemy, interactionParameters);
        interactionPanel.gameObject.SetActive(true);
        _ambiantSource.volume = _interactionMusicVolume;
        interactionBaseButton.Select();
    }

    public void ShowTuto()
    {
        tutoPanel.SetActive(true);
        GameManager.Instance.Freeze();
        tutoBaseButton.Select();
    }

    public void ShowWin(int bananaCount)
    {
        winPanel.SetActive(true);
        GameManager.Instance.Freeze();
        winBaseButton.Select();
    }

    public void ShowLoose(int bananaCount)
    {
        loosePanel.SetActive(true);
        GameManager.Instance.Freeze();
        looseBaseButton.Select();
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
        _ambiantSource.volume = 1.0f;
    }

    public void UpdateBanana(int bananas)
    {
        _bananaCounterText.text = bananas.ToString();
    }

    public void UpdateEncounter(int interactions)
    {
        _encounterCounterText.text = interactions.ToString();
        if (GameManager.Instance.HasEnoughInteractions)
            HutUpdate(GameManager.Instance.HasEnoughBananas);
    }

    private void HutUpdate(bool enoughBananas)
    {
        _hutImage.gameObject.SetActive(true);
        _hutArrow.gameObject.SetActive(enoughBananas);
    }

    public void OpenURL()
    {
        Application.OpenURL("https://dumas.ccsd.cnrs.fr/dumas-04382538");
    }
}
