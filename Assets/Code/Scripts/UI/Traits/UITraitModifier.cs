using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITraitModifier : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_modifierText;

    public void SetText(string text, Color color)
    {
        m_modifierText.text = text;
        m_modifierText.color = color;
    }
}
