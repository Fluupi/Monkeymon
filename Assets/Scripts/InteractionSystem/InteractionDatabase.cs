using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/InteractionDatabase", fileName = "InteractionDatabase")]
public class InteractionDatabase : ScriptableObject
{
    [SerializeField] private List<InteractionParameters> _parameters = null;
    public InteractionParameters GetParameters(int parameter)
    {
        return _parameters[parameter]; 
    }

    [SerializeField] private List<TupleResultData> _interactionResultData = null;
    public InteractionResultData GetResultData(InteractionResult parameter)
    {
        foreach(TupleResultData resultData in _interactionResultData)
        {
            if (resultData.Result == parameter)
                return resultData.Data;
        }
        return null;
    }
}

[Serializable]

public struct TupleResultData
{
    public InteractionResult Result;
    public InteractionResultData Data;
}