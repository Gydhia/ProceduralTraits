using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MentalTrait Preset", menuName = "Traits/MentalTrait")]
public class MentalTraitPreset : TraitPreset
{
    [SerializeField] private Sprite m_icon;
    [SerializeField] private string m_mentalSentence;
    
    public Sprite Icon => m_icon;
    public string MentalSentence => m_mentalSentence;
}
