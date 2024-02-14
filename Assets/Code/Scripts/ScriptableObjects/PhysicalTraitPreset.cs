using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MentalTrait Preset", menuName = "Traits/")]
public class PhysicalTraitPreset : TraitPreset
{
    [SerializeField] 
    private Dictionary<BodyPart, Sprite> m_characterAttributesModifier;

    public Dictionary<BodyPart, Sprite> CharacterAttributesModifier => m_characterAttributesModifier;
}
