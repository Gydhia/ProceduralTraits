using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PhysicalTrait Preset", menuName = "Traits/PhysicalTrait")]
public class PhysicalTraitPreset : TraitPreset
{
    [SerializeField] 
    private Dictionary<BodyPart, Sprite> m_bodySpriteModifier;
    [SerializeField] 
    private Dictionary<BodyPart, Sprite> m_bodyColorModifier;
    
    
    public Dictionary<BodyPart, Sprite> BodySpriteModifier => m_bodySpriteModifier;
}
