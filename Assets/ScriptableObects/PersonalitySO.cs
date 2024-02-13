using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum PersonalityEnum
{
    // Define your enum values here
}

[CreateAssetMenu(fileName = "PersonalityTraitsScriptableObject", 
                 menuName = "ScriptableObjects/PersonalityTraitsSO")]
public class PersonalitySO : SerializedScriptableObject
{
    [SerializeField] private Dictionary<PersonalityEnum, int> dataDictionary = new Dictionary<PersonalityEnum, int>();
    public Dictionary<PersonalityEnum, int> DataDictionary
    {
        get { return dataDictionary; }
        set { dataDictionary = value; }
    }
}
