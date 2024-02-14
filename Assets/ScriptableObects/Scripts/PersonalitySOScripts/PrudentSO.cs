using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Prudent",
    menuName = "ScriptableObjects/PrudentSO")]
public class PrudentSO : SerializedScriptableObject
{
    [SerializeField]
    Dictionary<Attributes.CharacterAttribute, int> characterAttribModifier;
}
