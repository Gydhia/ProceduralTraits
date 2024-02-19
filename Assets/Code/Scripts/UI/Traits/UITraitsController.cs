using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITraitsController : MonoBehaviour
{
    [SerializeField] private UITraitItem m_traitItemPrefab;
    [SerializeField] private RectTransform m_traitsHolder;

    [SerializeField] private RectTransform m_content;
    
    [SerializeField] private TMP_Dropdown m_AddTrait;

    private List<UITraitItem> m_traits = new List<UITraitItem>();

    private void Awake()
    {
        GameManager.OnCharacterChanged += UpdateVisibility;
    }

    private void RecreateTraitDropdown(CharacterData charData)
    {
        if (charData == null)
            return;
        
        m_AddTrait.options.Clear();
        
        string name = string.Empty;
        foreach (var pTrait in GeneratorManager.Instance.PhysicalTraitPresets)
        {
            bool isValid = pTrait.HasAnyIncompatibleTrait(charData.Traits);
            name = 
                pTrait.TraitName + 
                (charData.Traits.Contains(pTrait) ? "[ADDED]" : (isValid ? "" : "[Blocked]"));

            m_AddTrait.options.Add(new TMP_Dropdown.OptionData(text: name));
        }
        
        foreach (var mTrait in GeneratorManager.Instance.MentalTraitPresets)
        {
            bool isValid = mTrait.HasAnyIncompatibleTrait(charData.Traits);
            name = 
                mTrait.TraitName + 
                (charData.Traits.Contains(mTrait) ? "[ADDED]" : (isValid ? "" : "[Blocked]"));
            
            m_AddTrait.options.Add(new TMP_Dropdown.OptionData(text: name));
        }
    }

    public void Init()
    {
        m_AddTrait.onValueChanged.AddListener(OnDropDownSelection);
    }

    public void OnDropDownSelection(int index)
    {
        if (index < GeneratorManager.Instance.PhysicalTraitPresets.Count)
        {
            var trait = GeneratorManager.Instance.PhysicalTraitPresets[index];

            if (CharacterData.CurrentCharacterData.TryAddTrait(trait))
            {
                CreateTraitItem(trait);
                RecreateTraitDropdown(CharacterData.CurrentCharacterData);
            }
        }
        else
        {
            int scaledIndex = index - GeneratorManager.Instance.PhysicalTraitPresets.Count + 1;
            
            var trait = GeneratorManager.Instance.MentalTraitPresets[scaledIndex];

            if (CharacterData.CurrentCharacterData.TryAddTrait(trait))
            {
                CreateTraitItem(trait);
                RecreateTraitDropdown(CharacterData.CurrentCharacterData);
            }
        }
    }
    
    private void UpdateVisibility(CharacterData charData, CharacterData prevCharData)
    {
        if (charData == null)
        {
            m_content.gameObject.SetActive(false);
        }
        else
        {
            m_content.gameObject.SetActive(true);

            ClearList();
            
            for (int i = 0; i < charData.Traits.Count; i++)
            {
                CreateTraitItem(charData.Traits[i]);
            }
            
            RecreateTraitDropdown(charData);
        }
    }

    private void CreateTraitItem(TraitPreset preset)
    {
        var newTrait = Instantiate(m_traitItemPrefab, m_traitsHolder);
        newTrait.Init(preset);
        
        m_traits.Add(newTrait);
    }
    
    public void RemoveTrait(UITraitItem traitToRemove)
    {
        m_traits.Remove(traitToRemove);
        Destroy(traitToRemove.gameObject);
        
        RecreateTraitDropdown(CharacterData.CurrentCharacterData);
    }

    private void ClearList()
    {
        for (int i = 0; i < m_traits.Count; i++)
        {
            Destroy(m_traits[i].gameObject);
        }
        m_traits.Clear();
    }
}
