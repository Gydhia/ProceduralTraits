using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITraitIconsController : MonoBehaviour
{
    // Traits icons
    [SerializeField] private UITraitIcon m_traitIconPrefab;
    [SerializeField] private Transform m_traitsHolder;
    [SerializeField] private ToggleGroup m_toggleGroup;

    // Monologue
    [SerializeField] private TextMeshProUGUI m_monologueText;
    [SerializeField] private Image m_bottomBubble;
    [SerializeField] private float m_monologueDelay = 8f;

    private List<UITraitIcon> m_traitIcons = new List<UITraitIcon>();
    private Coroutine m_monologueCoroutine;
    private Coroutine m_textCoroutine;

    private void Awake()
    {
        GameManager.OnCharacterChanged += UpdateTraits;
    }

    private void UpdateTraits(CharacterData charData)
    {
        AbortMonologueCoroutines();
        
        if (charData == null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);

            ClearList();
            foreach (MentalTraitPreset mTrait in charData.MentalTraits)
            {
                var newIcon = Instantiate(m_traitIconPrefab, m_traitsHolder);

                newIcon.Init(mTrait);
                newIcon.SelfToggle.group = m_toggleGroup;
                newIcon.SelfToggle.onValueChanged.AddListener(
                    (state) => OnToggledIconChanged(newIcon, state)
                );

                m_traitIcons.Add(newIcon);
            }

            m_monologueCoroutine = StartCoroutine(PlayMonologues());
        }
    }

    private void OnToggledIconChanged(UITraitIcon icon, bool state)
    {
        AbortMonologueCoroutines();
        
        m_textCoroutine = StartCoroutine(ShowMonologueText(icon.MentalPreset));
    }

    private IEnumerator PlayMonologues()
    {
        for (int i = 0; i < m_traitIcons.Count; i++)
        {
            m_traitIcons[i].SelfToggle.SetIsOnWithoutNotify(true);
            
            m_textCoroutine = StartCoroutine(ShowMonologueText(m_traitIcons[i].MentalPreset));

            yield return new WaitForSeconds(m_monologueDelay);
        }

        m_monologueCoroutine = null;
    }

    private IEnumerator ShowMonologueText(MentalTraitPreset mPreset, float timeToShow = 0.4f)
    {
        Debug.Log("Started monlogue show");
        float delayPerCharacter = timeToShow / mPreset.MentalSentence.Length;

        m_bottomBubble.color = TraitPreset.GetColorFromType(mPreset.Type);
        
        m_monologueText.text = string.Empty;
        for (int i = 0; i < mPreset.MentalSentence.Length; i++)
        {
            m_monologueText.text += mPreset.MentalSentence[i];
            yield return new WaitForSeconds(delayPerCharacter);
        }

        Debug.Log("Ended monologue show");

        m_textCoroutine = null;
    }

    private void ClearList()
    {
        for (int i = 0; i < m_traitIcons.Count; i++)
        {
            Destroy(m_traitIcons[i].gameObject);
        }

        m_traitIcons.Clear();
    }

    private void AbortMonologueCoroutines()
    {
        if (m_monologueCoroutine != null)
            StopCoroutine(m_monologueCoroutine);
        m_monologueCoroutine = null;

        if (m_textCoroutine != null)
            StopCoroutine(m_textCoroutine);
        m_textCoroutine = null;
    }
}