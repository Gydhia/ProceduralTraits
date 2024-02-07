using System.Collections.Generic;
using UnityEngine;

public enum PersonalityEnum
{
    // Define your enum values here
}

[CreateAssetMenu(fileName = "PersonalityTraitsScriptableObject", menuName = "ScriptableObjects/PersonalityTraitsSO")]
public class PersonalitySO : ScriptableObject
{
    [SerializeField] private Dictionary<PersonalityEnum, int> dataDictionary = new Dictionary<PersonalityEnum, int>();
    public Dictionary<PersonalityEnum, int> DataDictionary
    {
        get { return dataDictionary; }
        set { dataDictionary = value; }
    }
}
