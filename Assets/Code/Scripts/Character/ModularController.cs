using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;


public enum SkinPart
{
    Head,
    Neck,
    LeftArm,
    RightArm,
    LeftLeg,
    RightLeg,
    LeftHand,
    RightHand,
    Nose,
    Mouth
}
public enum ClothPart
{
    None = 0,
    
    // Face
    Hair = 1,
    LeftEye = 2,
    RightEye = 3,
    LeftEyebrow = 4,
    RightEyebrow = 5,
    Nose = 6,
    Mouth = 7,
    
    // Clothes
    Torso = 20,
    LeftArm = 30,
    RightArm = 31,
    
    Pant = 40,
    LeftLeg = 41,
    RightLeg = 42,
    
    LeftShoe = 50,
    RightShoe = 51,
    
    // Decorations
    Scar = 60
}

public class ModularController : SerializedMonoBehaviour
{
    [Button]
    private void _fillDictionary()
    {
        m_clothes ??= new Dictionary<ClothPart, SpriteRenderer>();
        foreach (var part in Enum.GetNames(typeof(ClothPart)))
        {
            m_clothes.TryAdd(Enum.Parse<ClothPart>(part), null);
        }

        m_skins ??= new Dictionary<SkinPart, SpriteRenderer>();
        foreach (var part in Enum.GetNames(typeof(SkinPart)))
        {
            m_skins.TryAdd(Enum.Parse<SkinPart>(part), null);
        }
    }

    [SerializeField] 
    private List<Color> m_skinColor;
    [SerializeField] 
    private List<Color> m_clothesColor;
    [SerializeField] 
    private List<Color> m_eyesColor;
    [SerializeField] 
    private List<Color> m_hairColor;

    public List<Color> SkinColor => m_skinColor;
    public List<Color> ClothesColor => m_clothesColor;
    public List<Color> EyesColor => m_eyesColor;
    public List<Color> HairColor => m_hairColor;
    
    [SerializeField] 
    private List<Sprite> m_haircuts;
    [SerializeField] 
    private List<Sprite> m_eyes;
    [SerializeField] 
    private List<Sprite> m_eyebrows;
    [SerializeField] 
    private List<Sprite> m_nose;

    public List<Sprite> Haircuts => m_haircuts;
    public List<Sprite> Nose => m_nose;
    public List<Sprite> Eyes => m_eyes;
    public List<Sprite> Eyebrows => m_eyebrows;
    
    [OdinSerialize]
    private Dictionary<SkinPart, SpriteRenderer> m_skins;
    [OdinSerialize]
    private Dictionary<ClothPart, SpriteRenderer> m_clothes;

    [SerializeField] private GameObject m_visuals;

    private void Awake()
    {
        GameManager.OnCharacterChanged += UpdateVisuals;
    }

    public void ApplyVisuals(CharacterData charData)
    {
        
        foreach (var skinPart in m_skins)
            skinPart.Value.color = charData.CharacterVisuals.SkinColor;
        
        // Colors ---
        // Torso
        m_clothes[ClothPart.Torso].color = charData.CharacterVisuals.ShirtColor;
        // Sleeves
        m_clothes[ClothPart.LeftArm].color = m_clothes[ClothPart.RightArm].color = charData.CharacterVisuals.SleevesColor;
        // Legs
        m_clothes[ClothPart.Pant].color = m_clothes[ClothPart.LeftLeg].color =
            m_clothes[ClothPart.RightLeg].color = charData.CharacterVisuals.PantColor;
        // Hairs (eyebrows)
        m_clothes[ClothPart.Hair].color =
            m_clothes[ClothPart.LeftEyebrow].color = m_clothes[ClothPart.RightEyebrow].color = charData.CharacterVisuals.HairsColor;
        // Eyes
        m_clothes[ClothPart.LeftEye].color = m_clothes[ClothPart.RightEye].color = charData.CharacterVisuals.EyesColor;
        
        // Sprites ---
        m_clothes[ClothPart.LeftEye].sprite = m_clothes[ClothPart.RightEye].sprite= charData.CharacterVisuals.Eyes;
        m_clothes[ClothPart.LeftEyebrow].sprite = m_clothes[ClothPart.RightEyebrow].sprite = charData.CharacterVisuals.Eyebrows;
        m_clothes[ClothPart.Nose].sprite = charData.CharacterVisuals.Nose;
        m_clothes[ClothPart.Hair].sprite = charData.CharacterVisuals.Haircut;

    }
    
    private void UpdateVisuals(CharacterData charData)
    {
        if (charData == null)
        {
            m_visuals.SetActive(false);
        }
        else
        {
            m_visuals.SetActive(true);

            ApplyVisuals(charData);
        }
    }
}

public class CharacterVisuals
{
    public Color SkinColor;

    public Color ShirtColor;
    public Color SleevesColor;
    public Color PantColor;
    public Color HairsColor;
    public Color EyesColor;

    public Sprite Haircut;
    public Sprite Nose;
    public Sprite Eyes;
    public Sprite Eyebrows;

    public void Generate(System.Random generator, ModularController modularController)
    {
        SkinColor = modularController.SkinColor[generator.Next(0, modularController.SkinColor.Count)];
        
        ShirtColor = modularController.ClothesColor[generator.Next(0, modularController.ClothesColor.Count)];
        SleevesColor = modularController.ClothesColor[generator.Next(0, modularController.ClothesColor.Count)];
        PantColor = modularController.ClothesColor[generator.Next(0, modularController.ClothesColor.Count)];
        
        HairsColor = modularController.HairColor[generator.Next(0, modularController.HairColor.Count)];
        
        EyesColor = modularController.EyesColor[generator.Next(0, modularController.EyesColor.Count)];
        
        Haircut = modularController.Haircuts[generator.Next(0, modularController.Haircuts.Count)];
        Nose = modularController.Nose[generator.Next(0, modularController.Nose.Count)];
        Eyes = modularController.Eyes[generator.Next(0, modularController.Eyes.Count)];
        Eyebrows = modularController.Eyebrows[generator.Next(0, modularController.Eyebrows.Count)];
    }
}
