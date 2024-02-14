using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Timide",
    menuName = "ScriptableObjects/TimideSO")]
public class TimideSO : SerializedScriptableObject
{
    [SerializeField]
    Dictionary<Attributes.CharacterAttribute, int> characterAttribModifier;
}
