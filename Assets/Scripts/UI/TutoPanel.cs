using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TutoPanel : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tutoIntro;
    [SerializeField] private List<GameObject> _tutoRepetition;
    [SerializeField] private InputActionReference _inputInteraction;

    [SerializeField] private Image _mouseImage;
    [SerializeField] private Sprite _mouseOn;
    [SerializeField] private Sprite _mouseOff;
    [SerializeField] private float _mouseSwitchDelay;
    [SerializeField] private Image _bonolady;
    private bool _mouseRunning;

    private int i = 0;

    private List<GameObject> _currentTuto = null;

    private void Awake()
    {
        _currentTuto = _tutoIntro;
    }

    public void OnEnable()
    {
        if (_currentTuto == _tutoIntro)
            _bonolady.gameObject.SetActive(false);

        i = 0;
        _currentTuto[i].SetActive(true);

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
        if (i == 1 && _currentTuto == _tutoIntro)
            _bonolady.gameObject.SetActive(true);

        if (i >= _currentTuto.Count)
        {
            EndTuto();
            return;
        }
        _currentTuto[i].SetActive(false);
        i++;
        if (i < _currentTuto.Count)
        {
            _currentTuto[i].SetActive(true);
        }
        else
        {
            EndTuto();
        }
    }

    public void EndTuto()
    {
        _currentTuto = _tutoRepetition;
        UIManager.Instance.HideTutoPanel();
        _inputInteraction.action.started -= Action_started;
    }
}
