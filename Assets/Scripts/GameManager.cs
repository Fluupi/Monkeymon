using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private InteractionDatabase interactionDatabase;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private int BananaGain = 2;
    [SerializeField] private int BananaLoss = 2;

    private int _interaction = 0;
    private int _banana = 3;

    public int Banana { get; }

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
            case InteractionResult.Delouse:
            case InteractionResult.Exchange:
                AddBanana();
                break;
            case InteractionResult.RunAway:
            case InteractionResult.Fight:
                RemoveBanana();
                break;
        }

        return interactionDatabase.GetResultData(result);
    }

    public void AddBanana()
    {
        _banana += BananaLoss;
        UIManager.Instance.UpdateBanana();
    }

    public void RemoveBanana()
    {
        _banana -= BananaLoss;
        UIManager.Instance.UpdateBanana();
    }
}
