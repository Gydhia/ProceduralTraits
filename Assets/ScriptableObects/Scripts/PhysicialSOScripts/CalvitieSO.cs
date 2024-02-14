using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Calvitie", 
    menuName = "ScriptableObjects/CalvitieSO")]
public class CalvitieSO : SerializedScriptableObject
{

    [SerializeField]
    Dictionary<Attributes.CharacterAttribute, int> characterAttribModifier;
}
