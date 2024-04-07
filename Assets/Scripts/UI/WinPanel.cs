using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    public void Restart()
    {
        GameManager.Instance.RestartGame();
    }
}
