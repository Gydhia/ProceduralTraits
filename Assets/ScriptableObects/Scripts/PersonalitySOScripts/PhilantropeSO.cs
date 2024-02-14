using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Philantrope",
    menuName = "ScriptableObjects/PhilantropeSO")]
public class PhilantropeSO : SerializedScriptableObject
{
    [SerializeField]
    Dictionary<Attributes.CharacterAttribute, int> characterAttribModifier;
}
