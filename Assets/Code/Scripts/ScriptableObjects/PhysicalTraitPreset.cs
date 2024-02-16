using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PhysicalTrait Preset", menuName = "Traits/PhysicalTrait")]
public class PhysicalTraitPreset : TraitPreset
{
    [SerializeField] 
    private Dictionary<ClothPart, Sprite> m_bodySpriteModifier;
    [SerializeField] 
    private Dictionary<ClothPart, Sprite> m_bodyColorModifier;
    
    
    public Dictionary<ClothPart, Sprite> BodySpriteModifier => m_bodySpriteModifier;
}
