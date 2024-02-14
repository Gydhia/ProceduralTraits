using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "TailleImposante",
    menuName = "ScriptableObjects/TailleImposanteSO")]
public class TailleImposanteSO : SerializedScriptableObject
{

    [SerializeField]
    Dictionary<Attributes.CharacterAttribute, int> characterAttribModifier;
}
