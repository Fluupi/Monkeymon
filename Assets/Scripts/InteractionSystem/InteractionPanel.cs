using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InteractionPanel : MonoBehaviour
{
    
    [SerializeField] private AudioSource _audioSource;

    [Space]
    [SerializeField] private GameObject _playInteractionPanel;
    [SerializeField] private Image _enemyIllu;
    [SerializeField] private Image _playerIllu;
    [SerializeField] private Animator _soundIllu;

    [Space]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _delousingButton;
    [SerializeField] private Button _exchangeButton;
    [SerializeField] private Button _runAwayButton;

    [Space]
    [SerializeField] private Button _helpButton;
    [SerializeField] private GameObject _helpObject;
    [SerializeField] private Image _soundVisual;

    [Space]
    [SerializeField] private Image _resultIllu;
    [SerializeField] private InputActionReference _inputInteraction;

    private InteractionParameters _interactionParameters = null;
    private Monkenemy _monkenemy = null;

    private void Start()
    {
        _playButton.onClick.AddListener(OnPlayPressed);
        _delousingButton.onClick.AddListener(OnDelousingPressed);
        _exchangeButton.onClick.AddListener(OnExchangePressed);
        _runAwayButton.onClick.AddListener(OnRunAwayPressed);
        _helpButton.onClick.AddListener(OnHelpPressed);
    }

    public void Generate(Monkenemy monkenemy, InteractionParameters interactionParameters)
    {
        _interactionParameters = interactionParameters;
        _audioSource.clip = interactionParameters.AudioClip;
        _soundVisual.sprite = interactionParameters.AudioSprite;
        _monkenemy = monkenemy;
    }

    public void OnEnable()
    {
        bool forceHelp = GameManager.Instance.CurrentInteraction < GameManager.Instance.InteractionMax / 2;
        _helpButton.gameObject.SetActive(true);
        _helpObject.SetActive(forceHelp);
        StartCoroutine(Play());
        _inputInteraction.action.started += Action_started;
    }

    public void Replay()
    {
        StartCoroutine(Play());
    }

    public IEnumerator Play()
    {
        _enemyIllu.GetComponentInChildren<Animator>().Play("Play");
        if (_soundIllu.gameObject.activeInHierarchy)
        {
            _soundIllu.Play("Play");
        }
        yield return new WaitForSeconds(.5f);
        _audioSource.Play();
    }

    public void OnDisable()
    {
        _interactionParameters = null;
        _inputInteraction.action.started -= Action_started;
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

    public void OnHelpPressed()
    {
        _helpObject.SetActive(true);
        StartCoroutine(Play());
    }

    public void OnReplayPressed()
    {
        StartCoroutine(Play()); 
    }

    public void PlayAnswer(InteractionAnswer answer)
    {
        _helpButton.gameObject.SetActive(false);
        _helpObject.SetActive(false);
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
        _monkenemy.GetComponent<Monkenemy>().HideMonkeyAndBananas();
    }

    private void Action_started(InputAction.CallbackContext obj)
    {
        Replay();
    }
}
