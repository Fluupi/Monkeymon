using UnityEngine;
using UnityEngine.InputSystem;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private InputActionReference _inputInteraction;
    private Monkey _monkenemy;

    void Start()
    {
        _inputInteraction.action.started += Action_started;
    }

    private void Action_started(InputAction.CallbackContext obj)
    {
        if (_monkenemy != null)
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
            _monkenemy = monkenemy;
        }
    }
}
