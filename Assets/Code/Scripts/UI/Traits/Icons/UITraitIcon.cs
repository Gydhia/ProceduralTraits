using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UITraitIcon : MonoBehaviour
{
    [SerializeField] private Image m_icon;
    
    public Toggle SelfToggle;

    public MentalTraitPreset MentalPreset;

    public void Init(MentalTraitPreset mPreset)
    {
        MentalPreset = mPreset;
        m_icon.sprite = mPreset.Icon;
    }
    
    private void OnStateChanged(bool newState)
    {
        
    }
}
