using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Empire Preset", menuName = "ScriptableObjects/Empire")]
public class EmpirePreset : SerializedScriptableObject
{
    public Color EmpireColor;
    
    public string EmpireName;
    
    public List<string> Cities;
    public List<string> FirstNames;
    public List<string> LastNames;
}
