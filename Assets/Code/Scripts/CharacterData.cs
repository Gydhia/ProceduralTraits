using System;
using System.Collections;
using System.Collections.Generic;
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
        
        PhysicalTraits = new List<PhysicalTraitPreset>();
        MentalTraits = new List<MentalTraitPreset>();

        CharacterInfo = new CharacterInfo();
    }

    public Guid Seed;
    public List<PhysicalTraitPreset> PhysicalTraits { get; private set; }
    public List<MentalTraitPreset> MentalTraits { get; private set; }

    public CharacterInfo CharacterInfo;

    public void TryAddMentalTrait(MentalTraitPreset mPreset)
    {
        MentalTraits.Add(mPreset);
    }
    
    public void TryAddPhysicalTrait(PhysicalTraitPreset pPreset)
    {
        PhysicalTraits.Add(pPreset);
    }
}
