using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/InteractionDatabase", fileName = "InteractionDatabase")]
public class InteractionDatabase : ScriptableObject
{
    [SerializeField] private List<InteractionParameters> _parameters = null;

    [SerializeField] private List<TupleResultData> _interactionResultData = null;


    public InteractionParameters GetParameters(int parameter)
    {
        return _parameters[parameter]; 
    }

    private InteractionResultData GetResultData(InteractionResult parameter)
    {
        foreach(TupleResultData resultData in _interactionResultData)
        {
            if (resultData.Result == parameter)
                return resultData.Data;
        }
        return null;
    }

    private InteractionResult ComputeInteraction(Vocalization vocalization, InteractionAnswer answer)
    {
        if (answer == InteractionAnswer.RunAway)
        {
            return InteractionResult.RunAway;
        }
        else if (answer == vocalization.AwaitedAnswer)
        {
            switch (answer)
            {
                case InteractionAnswer.Play:
                    return InteractionResult.Play;
                case InteractionAnswer.FruitOffer:
                    return InteractionResult.Exchange;
                default:
                    return InteractionResult.Delouse;
            }
        }
        else
            return InteractionResult.Fight;
    }

    public InteractionResultData GetResultData(Vocalization vocalization, InteractionAnswer answer)
    {
        return GetResultData(ComputeInteraction(vocalization, answer));
    }
}

[Serializable]

public struct TupleResultData
{
    public InteractionResult Result;
    public InteractionResultData Data;
}