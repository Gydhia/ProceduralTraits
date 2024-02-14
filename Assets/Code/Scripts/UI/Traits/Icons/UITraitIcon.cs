using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITraitIcon : MonoBehaviour
{
    [SerializeField] private Image m_icon;
    
    public Toggle SelfToggle;

    public void Init(Sprite sprite)
    {
        m_icon.sprite = sprite;
    }
    
    private void OnStateChanged(bool newState)
    {
        
    }
}
