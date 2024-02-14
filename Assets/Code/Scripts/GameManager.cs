using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
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
        }
    }
    
    [Header("Seed")]
    public bool RegenerateSeed = true;

    [ShowInInspector]
    private Guid _seed;
    public Guid Seed
    {
        get
        {
            return _seed;
        }
        set
        {
            _seed = value;
            OnSeedUpdate?.Invoke(value);
        }
    }

    public static Action<Guid> OnSeedUpdate;

    public List<EmpirePreset> Empires;
    public System.Random Generator;

    [Button]
    public void Init()
    {
        if (RegenerateSeed)
        {
            Seed = Guid.NewGuid();
        }
        
        Generator = new System.Random(Seed.GetHashCode());
    }
}
