using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPanel : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Image _enemyIllu;
    [SerializeField] private Image _playerIllu;
    [SerializeField] private Image _soundVisual;
    [SerializeField] private Image _resultIllu;

    [SerializeField] private Button _playButton;
    [SerializeField] private Button _delousingButton;
    [SerializeField] private Button _exchangeButton;
    [SerializeField] private Button _runAwayButton;

    private InteractionParameters _interactionParameters = null;

    private void Start()
    {
        _playButton.onClick.AddListener(OnPlayPressed);
        _playButton.onClick.AddListener(OnDelousingPressed);
        _playButton.onClick.AddListener(OnExchangePressed);
        _playButton.onClick.AddListener(OnRunAwayPressed);
    }

    public void Generate(Monkenemy monkenemy, InteractionParameters interactionParameters)
    {
        _interactionParameters = interactionParameters;
        _enemyIllu.GetComponent<Animator>().runtimeAnimatorController = monkenemy.IlluSprite;
        _audioSource.clip = interactionParameters.AudioClip;
        _soundVisual.sprite = interactionParameters.AudioSprite;
    }

    public void OnEnable()
    {
        _audioSource.Play();
    }

    public void OnDisable()
    {
        _interactionParameters = null;
    }

    public void OnPlayPressed()
    {
        PlayAnswer(InteractionAnswer.Play);
    }

    public void OnDelousingPressed()
    {
        PlayAnswer(InteractionAnswer.Delouse);
    }

    public void OnExchangePressed()
    {
        PlayAnswer(InteractionAnswer.FruitOffer);
    }
    
    public void OnRunAwayPressed()
    {
        PlayAnswer(InteractionAnswer.RunAway);
    }

    public void PlayAnswer(InteractionAnswer answer)
    {
        var data = GameManager.Instance.GetResultData(_interactionParameters.Vocalization, answer);

        _audioSource.PlayOneShot(data.Sound);
        _resultIllu.sprite = data.Illustration;
    }
}
