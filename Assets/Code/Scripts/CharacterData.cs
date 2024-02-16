using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Characteristics
{
    None,
    
    Strength,
    Perception,
    Stamina,
    Charisma,
    Intelligence,
    Agility,
    Luck,
    MentalHealth,
    Creativity,
    Reflexes,
    Flexibility,
    Will,
    Speed,
    Oratory,
    Resiliency
}

public class CharacterData
{
    public CharacterData(Guid seed)
    {
        Seed = seed;
        
        Traits = new List<TraitPreset>();

        Characteristics = new Dictionary<Characteristics, int>();

        CharacterVisuals = new CharacterVisuals();
        
        CharacterInfo = new CharacterInfo();
    }

    public Guid Seed;
    public List<TraitPreset> Traits;
    public IEnumerable<PhysicalTraitPreset> PhysicalTraits 
        => Traits.OfType<PhysicalTraitPreset>();
    public IEnumerable<MentalTraitPreset> MentalTraits 
        => Traits.OfType<MentalTraitPreset>();

    public Dictionary<Characteristics, int> Characteristics;
    
    public CharacterInfo CharacterInfo;
    public CharacterVisuals CharacterVisuals;
    
    public void TryAddMentalTrait(MentalTraitPreset mPreset)
    {
        if (!Traits.Contains(mPreset))
        {
            Traits.Add(mPreset);
        }
    }
    
    public void TryAddPhysicalTrait(PhysicalTraitPreset pPreset)
    {
        if (!Traits.Contains(pPreset))
        {
            Traits.Add(pPreset);
        }
    }
}
