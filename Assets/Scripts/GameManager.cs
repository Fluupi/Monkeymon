using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private InteractionDatabase interactionDatabase;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private UIManager uiManager;

    private int _interaction = 0;

    public void StartInteraction(Monkenemy monkenemy)
    {
        uiManager.ShowInteraction(monkenemy, interactionDatabase.GetParameters(_interaction));
        playerMovement.Freeze();
    }

    public void EndInteraction()
    {
        _interaction++;
        uiManager.HideInteractionPanel();
        playerMovement.UnFreeze();
    }

    public InteractionResultData GetResultData(Vocalization vocalization, InteractionAnswer answer)
    {
        return interactionDatabase.GetResultData(vocalization, answer);
    }
}
