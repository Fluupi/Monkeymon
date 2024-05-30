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
    [SerializeField] private int BananaGoal = 5;
    [SerializeField] private int _interactionMax = 3;

    private int _interaction = 0;
    private int _banana = 3;

    public int CurrentInteraction => _interaction;
    public int InteractionMax => _interactionMax;

    public bool HasEnoughInteractions => _interaction >= _interactionMax;
    public bool HasEnoughBananas => _banana >= BananaGoal;

    public int Banana { get => _banana; }

    private void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
    }

    public void StartGame()
    {
        UIManager.Instance.UpdateBanana(_banana);
        UIManager.Instance.UpdateEncounter(_interaction);
        UIManager.Instance.ShowTuto();
    }

    public void StartInteraction(Monkey monkenemy)
    {
        if (monkenemy is Monkenemy enemy)
        {
            if (interactionDatabase.TryAndGetParameters(_interaction, out var param))
                uiManager.ShowInteraction(enemy, param);
            else
                enemy.transform.parent.gameObject.SetActive(false);
        }
        else if (monkenemy is Bonolady _)
        {
            if (!HasEnoughInteractions)
            {
                uiManager.ShowTuto();
            }
            else
            {
                if (HasEnoughBananas)
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
        UIManager.Instance.UpdateEncounter(_interaction);
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
                RemoveBanana(1);
                break;
            case InteractionResult.Fight:
                RemoveBanana(BananaDelta);
                break;
        }

        return interactionDatabase.GetResultData(result);
    }

    public void AddBanana()
    {
        _banana += BananaDelta;
        UIManager.Instance.UpdateBanana(_banana);
    }

    public void RemoveBanana(int delta)
    {
        _banana -= delta;
        if (_banana < 0)
        {
            _banana = 0;
        }
        UIManager.Instance.UpdateBanana(_banana);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
