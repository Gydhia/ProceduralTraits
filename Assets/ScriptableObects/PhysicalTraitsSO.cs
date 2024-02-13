using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public enum TPEnum
{
    // Define enum values for physical traits here
}

[CreateAssetMenu(fileName = "PhysicalTraits", menuName = "ScriptableObjects/PhysicalTraits")]
public class PhysicalTraitsSO : SerializedScriptableObject
{
    [SerializeField] private Dictionary<TPEnum, int> dataDictionary = new Dictionary<TPEnum, int>();

    public Dictionary<TPEnum, int> DataDictionary
    {
        get { return dataDictionary; }
        set { dataDictionary = value; }
    }
}
