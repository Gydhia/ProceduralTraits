using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            
            m_seedField.onValueChanged.AddListener(_processSeedInput);
            m_regenerateSeedToggle.onValueChanged.AddListener(_updateSeedRegen);

            GameManager.OnSeedUpdate += _updateSeed;
        }
    }

    [SerializeField] private Button m_regenerateButton;
    [SerializeField] private TMP_InputField m_seedField;
    [SerializeField] private Toggle m_regenerateSeedToggle;
    [SerializeField] private GameObject m_seedIncorrect;
    [SerializeField] private GameObject m_seedCurrentlyUsed;

    [SerializeField] private Color ValidColor;
    [SerializeField] private Color UnvalidColor;

    private Guid m_pendingSeed;

    public void OnClickGenerate()
    {
        m_seedCurrentlyUsed.SetActive(true);
        m_seedField.interactable = !GameManager.Instance.RegenerateSeed;

        if (!GameManager.Instance.RegenerateSeed)
        {
            GameManager.Instance.Seed = m_pendingSeed;
        }

        GameManager.Instance.Init();
    }
    
    private void _processSeedInput(string newValue)
    {
        bool isValid = Guid.TryParse(newValue, out Guid newSeed);
        m_seedIncorrect.SetActive(!isValid);
        m_seedCurrentlyUsed.SetActive(!GameManager.Instance.RegenerateSeed && GameManager.Instance.Seed == newSeed);

        if (isValid)
        {
            m_pendingSeed = newSeed;
            
            m_seedField.textComponent.color = ValidColor;
            m_regenerateButton.interactable = true;
        }
        else
        {
            m_seedField.textComponent.color = UnvalidColor;
            m_regenerateButton.interactable = false;
        }
    }
    
    private void _updateSeed(Guid seed)
    {
        m_seedField.text = seed.ToString();
    }

    private void _updateSeedRegen(bool enabled)
    {
        GameManager.Instance.RegenerateSeed = enabled;
        m_seedField.interactable = !enabled;
        m_seedCurrentlyUsed.SetActive(!enabled);
    }
}