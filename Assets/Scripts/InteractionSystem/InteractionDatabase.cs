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
}
