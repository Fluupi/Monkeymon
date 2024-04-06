using UnityEngine;

public class InteractionPanelManager : MonoBehaviour
{
    /*public static InteractionPanelManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [SerializeField] private InteractionPanel _interactionPanelPrefab = null;
    [SerializeField] private Transform _canvas = null;

    private InteractionPanel _interactionPanel = null;

    private void Start()
    {
        _interactionPanel = InteractionPanel.Instantiate(_interactionPanelPrefab, _canvas.transform);
        HidePanel();
    }

    public void GeneratePanel()
    {
        _interactionPanel.Generate();
    }

    public void HidePanel()
    {
        _interactionPanel.Hide();
    }*/
}
