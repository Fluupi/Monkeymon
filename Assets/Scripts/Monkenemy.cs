using UnityEngine;

public class Monkenemy : Monkey
{
    [SerializeField] private BoxCollider2D _monkeyCollider;
    [SerializeField] private CircleCollider2D _interactionCollider;
    [SerializeField] private GameObject _monkeySprite;
    [SerializeField] private GameObject[] _bananas;

    public void HideMonkeyAndBananas()
    {
        _monkeyCollider.enabled = false;
        _interactionCollider.enabled = false;

        _monkeySprite.SetActive(false);

        foreach(GameObject banana in _bananas)
            banana.SetActive(false);
    }
}
