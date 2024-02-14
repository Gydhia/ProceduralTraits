using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BeauteNaturelle",
    menuName = "ScriptableObjects/BeauteNaturelleSO")]
public class BeauteNaturelleSO : SerializedScriptableObject
{

    [SerializeField]
    Dictionary<Attributes.CharacterAttribute, int> characterAttribModifier;
}

