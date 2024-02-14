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

        m_AddTrait.options.Clear();
        
        foreach (var mTrait in GeneratorManager.Instance.MentalTraitPresets)
        {
            m_AddTrait.options.Add(new TMP_Dropdown.OptionData(text: mTrait.TraitName));
        }
        foreach (var mTrait in GeneratorManager.Instance.PhysicalTraitPresets)
        {
            m_AddTrait.options.Add(new TMP_Dropdown.OptionData(text: mTrait.TraitName));
        }
    }

    public void Init()
    {
        m_AddTrait.onValueChanged.AddListener(OnDropDownSelection);
    }

    public void OnDropDownSelection(int index)
    {
        Debug.Log("Trait to add : " + index);
    }
    
    private void UpdateVisibility(CharacterData charData)
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
                m_traits.Add(Instantiate(m_traitItemPrefab, m_traitsHolder));
                m_traits[^1].Init(charData.Traits[i]);
            }
        }
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
