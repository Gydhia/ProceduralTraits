using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class UITraitItem : MonoBehaviour
{
    [SerializeField] private Color m_bonusColor;
    [SerializeField] private Color m_malusColor;

    [SerializeField] private Button m_selfButton;
    
    [SerializeField] private UITraitModifier m_modifierPrefab;

    [SerializeField] private RectTransform m_selfTransform;
    [SerializeField] private RectTransform m_modifiersHolder;    
    [SerializeField] private TextMeshProUGUI m_traitName;

    private List<UITraitModifier> m_traitModifiers = new List<UITraitModifier>();

    private bool m_isExpended = false;
    
    public void Init(TraitPreset trait)
    {
        m_traitName.text = trait.TraitName;
        m_traitName.color = TraitPreset.GetColorFromType(trait.Type);
        
        if (trait.CharacterAttributesModifier == null)
        {
            m_selfButton.interactable = false;
        }
        else
        {
            m_selfButton.interactable = true;

            foreach (var attributeModifier in trait.CharacterAttributesModifier)
            {
                m_traitModifiers.Add(
                    Instantiate(m_modifierPrefab, m_modifiersHolder)
                );
            
                m_traitModifiers[^1].SetText(
                    attributeModifier.Value + " " + attributeModifier.Key,
                    attributeModifier.Value < 0 ? m_malusColor : m_bonusColor
                );
            }
        }
    }

    public void OnClickMainButton()
    {
        Vector2 endSize = m_isExpended ? 
            new Vector2(m_selfTransform.sizeDelta.x, 72f) :
            new Vector2(m_selfTransform.sizeDelta.x, m_selfTransform.sizeDelta.y + m_modifiersHolder.sizeDelta.y);
        m_isExpended = !m_isExpended;

        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)m_selfTransform.parent.transform);
        m_selfTransform.DOSizeDelta(endSize, 0.3f).OnUpdate(() => 
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)m_selfTransform.parent.transform));

    }
    
    public void OnClickRemoveButton()
    {
        
    }
}
