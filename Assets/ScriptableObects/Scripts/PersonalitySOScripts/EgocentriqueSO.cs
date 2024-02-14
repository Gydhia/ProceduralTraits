using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Egocentrique",
    menuName = "ScriptableObjects/EgocentriqueSO")]
public class EgocentriqueSO : SerializedScriptableObject
{
    [SerializeField]
    Dictionary<Attributes.CharacterAttribute, int> characterAttribModifier;
}

