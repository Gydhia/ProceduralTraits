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
    Will,
    Speed,
    Oratory
}

public class CharacterData
{
    public static CharacterData CurrentCharacterData;
    
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

    public int GetCharacteristicModifier(Characteristics chara)
        => Traits
            .Where(t => t.CharacterAttributesModifier != null && t.CharacterAttributesModifier.TryGetValue(chara, out int value))
            .Sum(t => t.CharacterAttributesModifier[chara]);
    
    public Dictionary<Characteristics, int> Characteristics;
    
    public CharacterInfo CharacterInfo;
    public CharacterVisuals CharacterVisuals;

    public Action<TraitPreset, bool> OnTraitChanged;
    
    public bool TryAddTrait(TraitPreset traitPreset)
    {
        if (!Traits.Contains(traitPreset) && traitPreset.HasAnyIncompatibleTrait(Traits) && traitPreset.HasRequiredTraits(Traits))
        {
            Traits.Add(traitPreset);
            OnTraitChanged?.Invoke(traitPreset, true);

            return true;
        }

        return false;
    }

    public bool TryRemoveTrait(TraitPreset traitPreset)
    {
        if (Traits.Contains(traitPreset) && !traitPreset.IsMandatory)
        {
            Traits.Remove(traitPreset);
            OnTraitChanged?.Invoke(traitPreset, false);

            return true;
        }

        return false;
    }
}
