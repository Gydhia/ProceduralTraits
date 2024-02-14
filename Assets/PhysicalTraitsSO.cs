using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;

[SerializeField]
public enum TPEnum
{
    
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
