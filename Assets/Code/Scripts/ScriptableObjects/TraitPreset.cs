using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] protected List<TraitPreset> m_requiredTraits;
    [SerializeField] protected List<TraitPreset> m_incompatibleTraits;
    [SerializeField] protected bool m_isMandatory = false;

    
    public Dictionary<Characteristics, int> CharacterAttributesModifier => m_characterAttributesModifier;
    public string TraitName => m_traitName;
    public List<TraitPreset> RequiredTraits => m_requiredTraits;
    public List<TraitPreset> IncompatibleTraits => m_incompatibleTraits;
    public bool IsMandatory => m_isMandatory;

    public bool IsIncompatibleToTrait(TraitPreset otherPreset)
        => m_incompatibleTraits.Contains(otherPreset);

    public bool HasRequiredTraits(List<TraitPreset> otherPresets)
        => !m_requiredTraits.Except(otherPresets).Any();
    
    public bool HasAnyIncompatibleTrait(List<TraitPreset> otherPresets)
        => !m_incompatibleTraits.Intersect(otherPresets).Any();
    
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
