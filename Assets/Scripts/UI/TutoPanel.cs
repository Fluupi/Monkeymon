using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TutoPanel : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tuto;
    [SerializeField] private InputActionReference _inputInteraction;

    [SerializeField] private Image _mouseImage;
    [SerializeField] private Sprite _mouseOn;
    [SerializeField] private Sprite _mouseOff;
    [SerializeField] private float _mouseSwitchDelay;
    private bool _mouseRunning;

    private int i = 0;

    private void Start()
    {
       // _inputInteraction.action.started += Action_started;
    }

    public void OnEnable()
    {
        i = 0;
        _tuto[i].SetActive(true);

        StartCoroutine(PlayMouse());
    }

    private void OnDisable()
    {
        _mouseRunning = false;
    }

    private IEnumerator PlayMouse()
    {
        _mouseRunning = true;

        while(_mouseRunning)
        {
            _mouseImage.sprite = _mouseImage.sprite == _mouseOn ? _mouseOff : _mouseOn;
            yield return new WaitForSeconds(_mouseSwitchDelay);
        }
    }

    private void Action_started(InputAction.CallbackContext obj)
    {
        Next();
    }

    public void Next()
    {
        if (i >= _tuto.Count)
        {
            EndTuto();
            return;
        }
        _tuto[i].SetActive(false);
        i++;
        if (i < _tuto.Count)
        {
            _tuto[i].SetActive(true);
        }
        else
        {
            EndTuto();
        }
    }

    public void EndTuto()
    {
        UIManager.Instance.HideTutoPanel();
        _inputInteraction.action.started -= Action_started;
    }
}
