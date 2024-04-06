using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPanel : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _delousingButton;
    [SerializeField] private Button _exchangeButton;
    [SerializeField] private Button _runAwayButton;

    private void Start()
    {
        _playButton.onClick.AddListener(OnPlayPressed);
        _playButton.onClick.AddListener(OnDelousingPressed);
        _playButton.onClick.AddListener(OnExchangePressed);
        _playButton.onClick.AddListener(OnRunAwayPressed);
    }

    public void OnPlayPressed()
    {
        InteractionPanelManager.Instance.HidePanel();
    }

    public void OnDelousingPressed()
    {
        InteractionPanelManager.Instance.HidePanel();
    }

    public void OnExchangePressed()
    {
        InteractionPanelManager.Instance.HidePanel();
    }
    
    public void OnRunAwayPressed()
    {
        InteractionPanelManager.Instance.HidePanel();
    }

    public void Generate()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
