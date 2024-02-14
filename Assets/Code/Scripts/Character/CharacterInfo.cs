using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CharacterInfo
{
    public string FirstName;
    public string LastName;
    
    public EmpirePreset BirthEmpire;
    public string BirthCity;
    
    public EmpirePreset CurrentEmpire;
    public string CurrentCity;

    public string Description;

    private static List<string> birthSentences = new List<string>
    {
        "%NOM% was born in the city of %VILLE_NAISSANCE% in the empire of %EMPIRE_NAISSANCE%. ",
        "During childhood, %NOM% lived in the city of %VILLE_NAISSANCE% where he learned the local customs. ",
        "%NOM%'s youth was marked by the lively streets of %VILLE_NAISSANCE%. ",
        "Born in %VILLE_NAISSANCE%, %NOM% grew up admiring the monuments of his empire. ",
        "%NOM% spent his childhood in %VILLE_NAISSANCE%, a city steeped in history and tradition. ",
        "%NOM%'s past in %VILLE_NAISSANCE% prepared him for the challenges of adult life. ",
        "%NOM%'s early years were filled with the sounds and smells of %VILLE_NAISSANCE%. "
    };

    private static List<string> currentSentences = new List<string>
    {
        "%NOM% currently resides in %VILLE_ACTUELLE%, where he is involved in community life. ",
        "Currently, %NOM% works in the city of %VILLE_ACTUELLE%. ",
        "Now established in %VILLE_ACTUELLE%, %NOM% explores the cultural riches of his new home. ",
        "%NOM% recently moved to %VILLE_ACTUELLE% to start a new life. ",
        "In %NOM%'s current life in %VILLE_ACTUELLE%, he seeks to fulfill himself fully. ",
        "%NOM%'s daily life in %VILLE_ACTUELLE% is filled with new encounters and discoveries. "
    };
    
    public void Generate(System.Random generator)
    {
        List<EmpirePreset> empires = GameManager.Instance.Empires;
        
        BirthEmpire = empires[generator.Next(0, empires.Count)];

        FirstName = BirthEmpire.FirstNames[generator.Next(0, BirthEmpire.FirstNames.Count)];
        LastName = BirthEmpire.LastNames[generator.Next(0, BirthEmpire.LastNames.Count)];
        
        BirthCity = BirthEmpire.Cities[generator.Next(0, BirthEmpire.Cities.Count)];

        CurrentEmpire = empires[generator.Next(0, empires.Count)];
        CurrentCity = CurrentEmpire.Cities[generator.Next(0, CurrentEmpire.Cities.Count)];

        string finalDesc = string.Empty;
        finalDesc += ProcessSentence(birthSentences[generator.Next(0, birthSentences.Count)]);
        finalDesc += "\n";
        if (BirthEmpire != CurrentEmpire)
        {
            finalDesc += ProcessSentence(currentSentences[generator.Next(0, currentSentences.Count)]);
        }

        Description = finalDesc;
    }

    private string ProcessSentence(string sentence)
    {
        return sentence
            .Replace("%NOM%", $"{FirstName} {LastName}")
            .Replace("%VILLE_NAISSANCE%", BirthCity)
            .Replace("%EMPIRE_NAISSANCE%", BirthEmpire.EmpireName)
            .Replace("%VILLE_ACTUELLE%", CurrentCity);
    }
}
