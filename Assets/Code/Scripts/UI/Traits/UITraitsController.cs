using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITraitsController : MonoBehaviour
{
    [SerializeField] private RectTransform m_content;
    
    [SerializeField] private TMP_Dropdown m_AddTrait;

    private void Awake()
    {
        GameManager.OnCharacterChanged += UpdateVisibility;
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
            
            // TODO update traits
        }
    }
}
