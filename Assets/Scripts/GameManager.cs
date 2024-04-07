using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private InteractionDatabase interactionDatabase;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private int BananaDelta = 2;
    [SerializeField] private int BananaGoal = 15;
    [SerializeField] private int InteractionMax = 3;

    private int _interaction = 0;
    private int _banana = 3;

    public int Banana { get => _banana; }

    public void StartGame()
    {
        playerMovement.UnFreeze();
        UIManager.Instance.UpdateBanana();
    }

    public void StartInteraction(Monkey monkenemy)
    {
        if (monkenemy is Monkenemy enemy)
        {
            uiManager.ShowInteraction(enemy, interactionDatabase.GetParameters(_interaction));
        }
        else
        if (monkenemy is Bonolady lady)
        {
            if (_interaction < InteractionMax)
            {
                uiManager.ShowTuto();
            }
            else
            {
                if (_banana > BananaGoal)
                {
                    uiManager.ShowWin(_banana);
                }
                else
                {
                    uiManager.ShowLoose(_banana);
                }
            }
        }
        Freeze();
    }

    public void EndInteraction()
    {
        _interaction++;
        uiManager.HideInteractionPanel();
        UnFreeze();
    }

    public void Freeze()
    {
        playerMovement.Freeze();
    }

    public void UnFreeze()
    {
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
        _banana += BananaDelta;
        UIManager.Instance.UpdateBanana();
    }

    public void RemoveBanana()
    {
        _banana -= BananaDelta;
        if (_banana < 0)
        {
            _banana = 0;
        }
        UIManager.Instance.UpdateBanana();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
