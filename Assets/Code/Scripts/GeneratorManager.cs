using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    [SerializeField] private List<PhysicalTraitPreset> m_physicalTraitPresets;
    [SerializeField] private List<MentalTraitPreset> m_mentalTraitPresets;

    [SerializeField] private ModularController m_modularController;
    
    public List<PhysicalTraitPreset> PhysicalTraitPresets => m_physicalTraitPresets;
    public List<MentalTraitPreset> MentalTraitPresets => m_mentalTraitPresets;
    
    public static GeneratorManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    
        GameManager.OnSeedUpdate += GenerateCharacter;
    }

    public void GenerateCharacter(Guid seed, System.Random generator)
    {
        CharacterData charData = new CharacterData(seed);
        
        int mentalTraitsNb = generator.Next(1, m_mentalTraitPresets.Count);
        int physicalTraitsNb = generator.Next(1, m_physicalTraitPresets.Count);

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
        
        foreach (Characteristics characteristic in Enum.GetValues(typeof(Characteristics)))
        {
            if (characteristic == Characteristics.None)
                continue;
            
            charData.Characteristics.Add(characteristic, generator.Next(1, 11));
        }

        charData.CharacterInfo.Generate(generator);
        charData.CharacterVisuals.Generate(generator, m_modularController);
        m_modularController.ApplyVisuals(charData);
        
        GameManager.OnCharacterChanged?.Invoke(charData);
    }
}
