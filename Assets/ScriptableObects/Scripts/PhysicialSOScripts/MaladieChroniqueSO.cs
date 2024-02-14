using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MaladieChronique",
    menuName = "ScriptableObjects/MaladieChroniqueSO")]
public class MaladieChroniqueSO : SerializedScriptableObject
{

    [SerializeField]
    Dictionary<Attributes.CharacterAttribute, int> characterAttribModifier;
}

