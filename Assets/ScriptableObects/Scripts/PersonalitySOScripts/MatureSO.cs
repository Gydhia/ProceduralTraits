using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Mature",
    menuName = "ScriptableObjects/MatureSO")]
public class MatureSO : SerializedScriptableObject
{
    [SerializeField]
    Dictionary<Attributes.CharacterAttribute, int> characterAttribModifier;
}
