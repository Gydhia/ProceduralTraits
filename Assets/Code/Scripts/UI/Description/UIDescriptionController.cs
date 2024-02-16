using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDescriptionController : MonoBehaviour
{
    [SerializeField] private UICharacteristicItem m_characteristicItemPrefab;
    [SerializeField] private Transform m_characteristicsHolder;
    
    [SerializeField] private RectTransform m_content;
    
    [SerializeField] private Image m_nameBackground;
    
    [SerializeField] private TextMeshProUGUI m_lastName; 
    [SerializeField] private TextMeshProUGUI m_firstName; 
    
    [SerializeField] private TextMeshProUGUI m_birthText; 
    [SerializeField] private TextMeshProUGUI m_currentText;
    [SerializeField] private Image m_birthIcon; 
    [SerializeField] private Image m_currentIcon;
    
    [SerializeField] private TextMeshProUGUI m_description;

    private List<UICharacteristicItem> m_characteristicItems = new List<UICharacteristicItem>();
    
    private void Awake()
    {
        foreach (string chara in Enum.GetNames(typeof(Characteristics)))
        {
            Characteristics characteristic = Enum.Parse<Characteristics>(chara);
            if(characteristic == Characteristics.None)
                continue;
            
            m_characteristicItems.Add(Instantiate(m_characteristicItemPrefab, m_characteristicsHolder));
            m_characteristicItems[^1].Init(characteristic);
        }
        
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)m_characteristicsHolder);
        
        GameManager.OnCharacterChanged += UpdateVisibility;
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

            var cInfo = charData.CharacterInfo;

            m_nameBackground.color = cInfo.CurrentEmpire.EmpireColor;
            
            m_firstName.text = cInfo.FirstName;
            m_lastName.text = cInfo.LastName;
        
            m_birthText.text = "[" + cInfo.BirthEmpire.EmpireName + "] " + cInfo.BirthCity;
            m_currentText.text = "[" + cInfo.CurrentEmpire.EmpireName + "] " + cInfo.CurrentCity;

            m_birthIcon.color = cInfo.BirthEmpire.EmpireColor;
            m_currentIcon.color = cInfo.CurrentEmpire.EmpireColor;

            m_description.text = cInfo.Description;

            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)m_birthText.transform.parent.transform.parent.transform);
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)m_description.transform);
        }
    }
    
}
