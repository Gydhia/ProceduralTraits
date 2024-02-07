using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

public enum BodyPart
{
    None = 0,
    
    Hair,
    LeftEye,
    RightEye,
    LeftEyebrow,
    RightEyebrow,
    Nose,
    Mouth,
    
    Torso,
    LeftArm,
    RightArm,
    
    Pant,
    LeftLeg,
    RightLeg,
    LeftShoe,
    RightShoe,
    
    Scar
}

public class ModularController : SerializedMonoBehaviour
{
    [Button]
    private void _fillDictionary()
    {
        m_body ??= new Dictionary<BodyPart, SpriteRenderer>();
        foreach (var part in Enum.GetNames(typeof(BodyPart)))
        {
            m_body.TryAdd(Enum.Parse<BodyPart>(part), null);
        }
    }
    
    [OdinSerialize]
    private Dictionary<BodyPart, SpriteRenderer> m_body;
    
    
}
