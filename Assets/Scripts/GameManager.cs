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
        InteractionResult result = interactionDatabase.ComputeInteraction(vocalization, answer);

        switch(result)
        {
            case InteractionResult.Play:
                //+2;
                break;
            case InteractionResult.Delouse:
                //+1;
                break;
            case InteractionResult.Exchange:
                //+1?;
                break;
            case InteractionResult.RunAway:
                //-1;
                break;
            case InteractionResult.Fight:
                //-2;
                break;
        }

        return interactionDatabase.GetResultData(result);
    }
}
