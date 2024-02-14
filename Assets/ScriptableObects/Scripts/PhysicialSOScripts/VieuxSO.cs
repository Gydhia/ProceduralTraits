using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Vieux",
    menuName = "ScriptableObjects/VieuxSO")]
public class VieuxSO : SerializedScriptableObject
{

    [SerializeField]
    Dictionary<Attributes.CharacterAttribute, int> characterAttribModifier;
}