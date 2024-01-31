using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            init();

            SeedField.onValueChanged.AddListener(_updateSeed);
            RegenerateSeedToggle.onValueChanged.AddListener(_updateSeedRegen);
        }
    }
    
    private void _updateSeed(string newValue)
    {
        Guid.TryParse(newValue, out this.Seed);
    }

    private void _updateSeedRegen(bool enabled)
    {
        RegenerateSeed = enabled;
        SeedField.interactable = !enabled;
    }

    public TMP_InputField SeedField;
    public Toggle RegenerateSeedToggle;
    
    [Header("Seed")]
    public bool RegenerateSeed;
    [ShowInInspector]
    public Guid Seed;
    public System.Random Generator;

    [Button]
    public void init()
    {
        if (RegenerateSeed)
        {
            Seed = Guid.NewGuid();
            this.SeedField.text = Seed.ToString();
        }

        SeedField.interactable = !RegenerateSeed;
        
        Generator = new System.Random(Seed.GetHashCode());
    }
    
    
}
