using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    public CharactersData datas;
    // Start is called before the first frame update
    void Start()
    {
        if (datas == null)
            Debug.LogError("No datas");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(datas.getPhysicalTraits().Count);
    }

    public int GeneratePhysicalTrait()
    {
        Debug.Log(datas.getPhysicalTraits().Count);
        return GameManager.Instance.Generator.Next(0, datas.getPhysicalTraits().Count);
    }

    public int GeneratePersonalityTrait()
    {
        return GameManager.Instance.Generator.Next(0, datas.getPersonnalityTraits().Count);
    }

}
