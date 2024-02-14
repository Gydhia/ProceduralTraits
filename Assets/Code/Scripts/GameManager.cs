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

    [Header("Characters Pictures")] [SerializeField]
    public Camera PictureCamera;
    
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
            Generator = new System.Random(_seed.GetHashCode());
            OnSeedUpdate?.Invoke(value, Generator);
        }
    }

    public static Action<Guid, System.Random> OnSeedUpdate;
    public static Action<CharacterData> OnCharacterChanged;

    public List<EmpirePreset> Empires;
    public System.Random Generator;

    private void Start()
    {
        OnCharacterChanged?.Invoke(null);
    }
}
