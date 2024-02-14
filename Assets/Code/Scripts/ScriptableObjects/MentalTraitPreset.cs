using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MentalTrait Preset", menuName = "Traits/")]
public class MentalTraitPreset : TraitPreset
{
    [SerializeField] private Dictionary<Characteristics, int> m_characterAttributesModifier;
    [SerializeField] private Sprite m_icon;
    [SerializeField] private string m_mentalSentence;
    
    public Dictionary<Characteristics, int> CharacterAttributesModifier => m_characterAttributesModifier;
    public Sprite Icon => m_icon;
    public string MentalSentence => m_mentalSentence;
}
