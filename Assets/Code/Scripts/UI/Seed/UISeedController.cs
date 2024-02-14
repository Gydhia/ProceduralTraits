using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISeedController : MonoBehaviour
{
    [SerializeField] private Button m_regenerateButton;
    [SerializeField] private TMP_InputField m_seedField;
    [SerializeField] private Toggle m_regenerateSeedToggle;
    [SerializeField] private GameObject m_seedIncorrect;
    [SerializeField] private GameObject m_seedCurrentlyUsed;
    [SerializeField] private TextMeshProUGUI m_confirmCopy;
    
    private Guid m_pendingSeed;

    public void Init()
    {
        m_seedField.onValueChanged.AddListener(_processSeedInput);
        m_regenerateSeedToggle.onValueChanged.AddListener(_updateSeedRegen);
        
        GameManager.OnSeedUpdate += _updateSeed;
    }
    
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

    public void OnClickCopy()
    {
        GUIUtility.systemCopyBuffer = m_seedField.text;

        m_confirmCopy.DOFade(1f, 0.2f);
        m_confirmCopy.DOFade(0f, 0.15f).SetDelay(1.5f); 
    }
    
    private void _processSeedInput(string newValue)
    {
        bool isValid = Guid.TryParse(newValue, out Guid newSeed);
        m_seedIncorrect.SetActive(!isValid);
        m_seedCurrentlyUsed.SetActive(!GameManager.Instance.RegenerateSeed && GameManager.Instance.Seed == newSeed);

        if (isValid)
        {
            m_pendingSeed = newSeed;
            
            m_seedField.textComponent.color = UIManager.Instance.ValidColor;
            m_regenerateButton.interactable = true;
        }
        else
        {
            m_seedField.textComponent.color = UIManager.Instance.UnvalidColor;
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
