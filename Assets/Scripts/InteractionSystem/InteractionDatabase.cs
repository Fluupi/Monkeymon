using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/InteractionDatabase", fileName = "InteractionDatabase")]
public class InteractionDatabase : ScriptableObject
{
    [SerializeField] private List<InteractionParameters> _parameters = null;

    [SerializeField] private List<TupleResultData> _interactionResultData = null;

    public int ParametersCount { get { return _parameters.Count;  } }

    public bool TryAndGetParameters(int parameter, out InteractionParameters param)
    {
        if (parameter < _parameters.Count)
        {
            param = _parameters[parameter];
            return true;
        }

        param = null;
        return false;
    }

    public InteractionResultData GetResultData(InteractionResult parameter)
    {
        foreach(TupleResultData resultData in _interactionResultData)
        {
            if (resultData.Result == parameter)
                return resultData.Data;
        }
        return null;
    }

    public InteractionResult ComputeInteraction(Vocalization vocalization, InteractionAnswer answer)
    {
        if (answer == InteractionAnswer.RunAway)
        {
            return InteractionResult.RunAway;
        }
        else if (answer == vocalization.AwaitedAnswer)
        {
            return answer switch
            {
                InteractionAnswer.Play => InteractionResult.Play,
                InteractionAnswer.FruitOffer => InteractionResult.Exchange,
                _ => InteractionResult.Delouse,
            };
        }
        else
            return InteractionResult.Fight;
    }
}

[Serializable]

public struct TupleResultData
{
    public InteractionResult Result;
    public InteractionResultData Data;
}