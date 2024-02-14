using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITraitIconsController : MonoBehaviour
{
    // Traits icons
    [SerializeField] private UITraitIcon m_traitIconPrefab;
    [SerializeField] private Transform m_traitsHolder;
    [SerializeField] private ToggleGroup m_toggleGroup;

    // Monologue
    [SerializeField] private TextMeshProUGUI m_monologueText;
    [SerializeField] private Image m_bottomBubble;
    
    private List<UITraitIcon> m_traitIcons;

    private void Awake()
    {
        GameManager.OnCharacterChanged += UpdateTraits;
    }

    private void UpdateTraits(CharacterData charData)
    {
        if (charData == null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            
            for (int i = 0; i < charData.MentalTraits.Count; i++)
            {
                var newIcon = Instantiate(m_traitIconPrefab, m_traitsHolder);
            
                newIcon.Init(charData.MentalTraits[i].Icon);
                newIcon.SelfToggle.onValueChanged.AddListener(
                    (state) => OnToggledIconChanged(newIcon, state)
                );
            }
        }
    }
    
    private void OnToggledIconChanged(UITraitIcon icon, bool state)
    {
        
    }
    
    public void OnTraitChanged()
    {
        
    }
}
