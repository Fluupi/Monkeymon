using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoPanel : MonoBehaviour
{
    public void EndTuto()
    {
        UIManager.Instance.HideTutoPanel();
    }
}
