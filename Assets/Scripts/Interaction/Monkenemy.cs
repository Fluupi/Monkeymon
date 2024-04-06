using UnityEngine;
using UnityEngine.InputSystem;

public class Monkenemy : MonoBehaviour
{
    [SerializeField] private InputAction _inputInteraction;

    void Start()
    {
        _inputInteraction.Enable();
    }

    void Update()
    {
        if (_inputInteraction.IsPressed())
        {
            InteractionPanelManager.Instance.GeneratePanel();
        }
    }
}
