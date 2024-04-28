using UnityEngine;
using UnityEngine.InputSystem;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private InputActionReference _inputInteraction;
    [SerializeField] private Monkey _monkenemy;
    private PlayerMovement _playerMovement;

    void Start()
    {
        _playerMovement = transform.parent.GetComponent<PlayerMovement>();
        _inputInteraction.action.started += Action_started;
    }

    private void Action_started(InputAction.CallbackContext obj)
    {
        if (_monkenemy != null && _playerMovement.Freezed == false)
        {
            GameManager.Instance.StartInteraction(_monkenemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.TryGetComponent<Monkey>(out var monkenemy))
        {
            monkenemy.OpenIndicator();
            _monkenemy = monkenemy;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Monkey>(out var monkenemy))
        {
            monkenemy.CloseIndicator();
            _monkenemy = null;
        }
    }
}
