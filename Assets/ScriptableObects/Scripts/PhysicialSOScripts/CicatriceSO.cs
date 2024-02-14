using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Cicatrice",
    menuName = "ScriptableObjects/CicatriceSO")]
public class CicatriceSO : SerializedScriptableObject
{

    [SerializeField]
    Dictionary<Attributes.CharacterAttribute, int> characterAttribModifier;
}
