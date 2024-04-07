using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPanel : MonoBehaviour
{
    
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private GameObject _playInteractionPanel;
    [SerializeField] private Image _enemyIllu;
    [SerializeField] private Image _playerIllu;
    [SerializeField] private Image _soundVisual;

    [SerializeField] private Button _playButton;
    [SerializeField] private Button _delousingButton;
    [SerializeField] private Button _exchangeButton;
    [SerializeField] private Button _runAwayButton;

    [SerializeField] private Image _resultIllu;

    private InteractionParameters _interactionParameters = null;

    private void Start()
    {
        _playButton.onClick.AddListener(OnPlayPressed);
        _delousingButton.onClick.AddListener(OnDelousingPressed);
        _exchangeButton.onClick.AddListener(OnExchangePressed);
        _runAwayButton.onClick.AddListener(OnRunAwayPressed);
    }

    public void Generate(Monkenemy monkenemy, InteractionParameters interactionParameters)
    {
        _interactionParameters = interactionParameters;
        _audioSource.clip = interactionParameters.AudioClip;
        _soundVisual.sprite = interactionParameters.AudioSprite;
    }

    public void OnEnable()
    {
        StartCoroutine(Play());
    }

    public IEnumerator Play()
    {
        yield return new WaitForSeconds(.25f);
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

        Debug.Log(data.name);
        _playInteractionPanel.SetActive(false);
        _resultIllu.gameObject.SetActive(true);
        _resultIllu.sprite = data.Illustration;
        _audioSource.PlayOneShot(data.Sound);

        StartCoroutine(WaitForHideInteraction());
    }

    private IEnumerator WaitForHideInteraction()
    {
        yield return new WaitWhile(() => _audioSource.isPlaying);

        _resultIllu.gameObject.SetActive(false);
        _playInteractionPanel.SetActive(true);

        GameManager.Instance.EndInteraction();
    }
}
