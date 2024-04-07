using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoosePanel : MonoBehaviour
{
    public void Restart()
    {
        GameManager.Instance.RestartGame();
    }
}
