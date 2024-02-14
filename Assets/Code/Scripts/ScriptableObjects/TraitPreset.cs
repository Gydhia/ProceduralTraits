using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public enum TraitType
{
    Good,
    Mixed,
    Bad
}

public class TraitPreset : SerializedScriptableObject
{
    public TraitType Type;
    
    [SerializeField] private string m_traitName;
    [SerializeField] protected Dictionary<Characteristics, int> m_characterAttributesModifier;
    public Dictionary<Characteristics, int> CharacterAttributesModifier => m_characterAttributesModifier;
    public string TraitName => m_traitName;


    public static Color GetColorFromType(TraitType type)
    {
        switch (type)
        {
            default:
            case TraitType.Good:
                return UIManager.Instance.GoodColor;
            case TraitType.Mixed:
                return UIManager.Instance.MixedColor;
            case TraitType.Bad:
                return UIManager.Instance.BadColor;
        }
        
    }
}
