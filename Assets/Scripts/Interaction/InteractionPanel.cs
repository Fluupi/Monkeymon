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
        GameManager.Instance.EndInteraction();
    }

    public void OnDelousingPressed()
    {
        GameManager.Instance.EndInteraction();
    }

    public void OnExchangePressed()
    {
        GameManager.Instance.EndInteraction();
    }
    
    public void OnRunAwayPressed()
    {
        GameManager.Instance.EndInteraction();
    }
}
