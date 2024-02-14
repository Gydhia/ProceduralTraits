using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDescriptionController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_lastName; 
    [SerializeField] private TextMeshProUGUI m_firstName; 

    
    [SerializeField] private TextMeshProUGUI m_birthText; 
    [SerializeField] private TextMeshProUGUI m_currentText;
    
    [SerializeField] private TextMeshProUGUI m_description; 

    
    public void Init(CharacterInfo cInfo)
    {
        m_firstName.text = cInfo.FirstName;
        m_lastName.text = cInfo.LastName;
        
        m_birthText.text = "Birthplace : " + cInfo.BirthCity + " [" + cInfo.BirthEmpire + "]";
        m_currentText.text = "Living place : " + cInfo.CurrentCity + " [" + cInfo.CurrentEmpire + "]";

        m_description.text = cInfo.Description;
    }
}
