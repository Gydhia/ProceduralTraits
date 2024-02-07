using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITraitsController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown m_AddTrait;
    
    public void Init()
    {
        m_AddTrait.onValueChanged.AddListener(OnDropDownSelection);
    }

    public void OnDropDownSelection(int index)
    {
        Debug.Log("Trait to add : " + index);
    }
}
