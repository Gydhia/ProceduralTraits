using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [Header("Personality traits")]
    [SerializeField] AllergieSO soAllergie;
    [SerializeField] AltruisteSO soAltruiste;
    [SerializeField] AnxieuxSO soAnxieux;
    [SerializeField] ArrogantSO soArrogant;
    [SerializeField] EgocentriqueSO soEgocentrique;
    [SerializeField] ExtravertiSO soExtraverti;
    [SerializeField] FourbeSO soFourbe;
    [SerializeField] KleptomaneSO soKleptomane;
    [SerializeField] MaldadresseSO soMaladresse;
    [SerializeField] MatureSO soMature;
    [SerializeField] MelancoliqueSO soMelancolique;
    [SerializeField] NihilisteSO soNihiliste;
    [SerializeField] PhilantropeSO soPhilantrope;
    [SerializeField] PrudentSO soPrudent;
    [SerializeField] TimideSO soTimide;


    [Header("Physical traits")]
    [SerializeField] CalvitieSO soCalvitie;
    [SerializeField] CicatriceSO soCicatrice;
    [SerializeField] JeuneSO soJeune;
    [SerializeField] MaladieChroniqueSO soMaladieChronique;
    [SerializeField] MalvoyantSO soMalvoyant;
    [SerializeField] TailleImposanteSO soTailleImposante;
    [SerializeField] VieuxSO soVieux;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
