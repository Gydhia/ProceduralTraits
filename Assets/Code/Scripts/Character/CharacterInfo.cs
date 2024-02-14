using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public string FirstName;
    public string LastName;
    
    public string BirthEmpire;
    public string BirthCity;
    
    public string CurrentEmpire;
    public string CurrentCity;

    public string Description;

    private static List<string> birthSentences = new List<string>
    {
        "%NOM% est né dans la ville de %VILLE_NAISSANCE% dans l'empire de %EMPIRE_NAISSANCE%. ",
        "Dans son enfance, %NOM% a vécu dans la ville de %VILLE_NAISSANCE% où il a appris les coutumes locales. ",
        "La jeunesse de %NOM% a été marquée par les ruelles animées de %VILLE_NAISSANCE%. ",
        "Né à %VILLE_NAISSANCE%, %NOM% a grandi en admirant les monuments de son empire. ",
        "%NOM% a passé son enfance à %VILLE_NAISSANCE%, une ville imprégnée d'histoire et de tradition. ",
        "Le passé de %NOM% à %VILLE_NAISSANCE% l'a préparé aux défis de la vie adulte. ",
        "Les premières années de %NOM% ont été bercées par les bruits et les odeurs de %VILLE_NAISSANCE%. "
    };

    private static List<string> currentSentences = new List<string>
    {
        "%NOM% réside actuellement à %VILLE_ACTUELLE%, où il s'implique dans la vie communautaire. ",
        "À présent, %NOM% travaille dans la ville de %VILLE_ACTUELLE%. ",
        "Actuellement établi à %VILLE_ACTUELLE%, %NOM% explore les richesses culturelles de sa nouvelle demeure. ",
        "%NOM% a récemment déménagé à %VILLE_ACTUELLE% pour démarrer une nouvelle vie. ",
        "Dans sa vie actuelle à %VILLE_ACTUELLE%, %NOM% cherche à se réaliser pleinement. ",
        "La vie quotidienne de %NOM% à %VILLE_ACTUELLE% est teintée de nouvelles rencontres et découvertes. "
    };
    
    public void Generate(System.Random generator)
    {
        List<EmpirePreset> empires = GameManager.Instance.Empires;
        
        EmpirePreset birthEmpire = empires[generator.Next(0, empires.Count)];

        FirstName = birthEmpire.FirstNames[generator.Next(0, birthEmpire.FirstNames.Count)];
        LastName = birthEmpire.LastNames[generator.Next(0, birthEmpire.LastNames.Count)];
        
        BirthEmpire = birthEmpire.EmpireName;
        BirthCity = birthEmpire.Cities[generator.Next(0, birthEmpire.Cities.Count)];

        EmpirePreset currentEmpire = empires[generator.Next(0, empires.Count)];
        CurrentEmpire = currentEmpire.EmpireName;
        CurrentCity = currentEmpire.Cities[generator.Next(0, currentEmpire.Cities.Count)];

        string finalDesc = string.Empty;
        finalDesc += ProcessSentence(birthSentences[generator.Next(0, birthSentences.Count)]);
        finalDesc += "\n";
        if (birthEmpire != currentEmpire)
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
            .Replace("%EMPIRE_NAISSANCE%", BirthEmpire)
            .Replace("%VILLE_ACTUELLE%", CurrentCity);
    }
}