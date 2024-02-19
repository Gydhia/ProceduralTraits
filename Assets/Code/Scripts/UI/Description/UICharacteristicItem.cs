using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICharacteristicItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_characteristicName;
    [SerializeField] private TextMeshProUGUI m_characteristicValue;

    private Characteristics m_refCharacteristic;

    private void Awake()
    {
        GameManager.OnCharacterChanged += OnCharacterChanged;      
    }


    public void Init(Characteristics characteristic)
    {
        m_refCharacteristic = characteristic;
        m_characteristicName.text = characteristic.ToString();
    }
    
    
    private void OnCharacterChanged(CharacterData charData, CharacterData prevCharData)
    {
        if (prevCharData != null)
            prevCharData.OnTraitChanged -= UpdateCharacteristics;
        
        if (charData == null)
            return;

        charData.OnTraitChanged += UpdateCharacteristics;
        
        UpdateCharacteristics(charData);
    }

    private void UpdateCharacteristics(TraitPreset preset, bool added)
    {
        UpdateCharacteristics(CharacterData.CurrentCharacterData);
    }
    
    private void UpdateCharacteristics(CharacterData charData)
    {
        int modifier = charData.GetCharacteristicModifier(m_refCharacteristic);
        int finalValue = Math.Clamp(charData.Characteristics[m_refCharacteristic] + modifier, 0, 10);
        
        m_characteristicValue.text = finalValue.ToString();

        if (modifier < 0)
            m_characteristicValue.color = UIManager.Instance.UnvalidColor;
        else if (modifier > 0)
            m_characteristicValue.color = UIManager.Instance.GoodColor;
        else
            m_characteristicValue.color = Color.white;
    }
}
