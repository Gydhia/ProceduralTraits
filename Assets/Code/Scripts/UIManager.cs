using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
        }
    }
    
    public Color ValidColor;
    public Color UnvalidColor;
    
    public UISeedController SeedController;
    public UIDescriptionController DescriptionController;
    public UITraitsController TraitsController;

    private void Start()
    {
        SeedController.Init();
        DescriptionController.Init(null);
        TraitsController.Init();
    }
}