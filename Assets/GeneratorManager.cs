using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    [SerializeField] private List<PhysicalTraitPreset> m_physicalTraitPresets;
    [SerializeField] private List<MentalTraitPreset> m_mentalTraitPresets;
    
    private void Awake()
    {
        GameManager.OnSeedUpdate += GenerateCharacter;
    }

    public void GenerateCharacter(Guid seed, System.Random generator)
    {
        CharacterData charData = new CharacterData(seed);
        
        int mentalTraitsNb = generator.Next(0, m_mentalTraitPresets.Count);
        int physicalTraitsNb = generator.Next(0, m_physicalTraitPresets.Count);

        for (int i = 0; i < mentalTraitsNb; i++)
        {
            var mTrait = m_mentalTraitPresets[generator.Next(0, m_mentalTraitPresets.Count)];
            
            charData.TryAddMentalTrait(mTrait);
        }
        
        for (int i = 0; i < physicalTraitsNb; i++)
        {
            var pTrait = m_physicalTraitPresets[generator.Next(0, m_physicalTraitPresets.Count)];

            charData.TryAddPhysicalTrait(pTrait);
        }
        
        charData.CharacterInfo.Generate(generator);
        
        GameManager.OnCharacterChanged?.Invoke(charData);
    }
}
