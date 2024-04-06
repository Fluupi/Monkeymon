using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractionComputer : Singleton<InteractionComputer>
{
    public List<InteractionOutput> _dictionnary;

    public InteractionResult ComputeInteraction(Vocalization vocalization, InteractionAnswer answer)
    {
        List<InteractionOutput> foundOutputInList = _dictionnary.Where(output => output.input.vocalization == vocalization && output.input.answer == answer).ToList();

        if (foundOutputInList.Count != 1)
            Debug.LogError("TU M'CHERCHES LA ?");

        return foundOutputInList.ToList()[0].result;
    }
}

[Serializable]
public struct InteractionOutput
{
    public InteractionInput input;
    public InteractionResult result;
}

[Serializable]
public struct InteractionInput
{
    public Vocalization vocalization;
    public InteractionAnswer answer;
}
