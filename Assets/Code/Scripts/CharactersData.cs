using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersData : MonoBehaviour
{
    public  List<ScriptableObject> personalityTraits = new List<ScriptableObject>();
    public  List<ScriptableObject> physicalTraits = new List<ScriptableObject>();

    public List<ScriptableObject> getPersonnalityTraits()
    {
        return personalityTraits;
    }

    public List<ScriptableObject> getPhysicalTraits()
    {
        return physicalTraits;
    }

}
