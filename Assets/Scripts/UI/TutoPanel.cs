using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoPanel : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tuto;

    private int i = 0;

    public void OnEnable()
    {
        i = 0;
        _tuto[i].SetActive(true);
    }

    public void Next()
    {
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
    }
}
