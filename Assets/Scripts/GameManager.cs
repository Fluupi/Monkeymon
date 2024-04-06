using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private UIManager uiManager;

    public void StartInteraction(Monkenemy monkenemy)
    {
        uiManager.ShowInteraction(monkenemy);
        playerMovement.Freeze();
    }

    public void EndInteraction()
    {
        uiManager.HideInteractionPanel();
        playerMovement.UnFreeze();
    }

    
}
