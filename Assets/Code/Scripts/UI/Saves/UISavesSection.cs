using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISavesSection : MonoBehaviour
{
    [SerializeField] private List<UISaveItem> m_saveItems;

    public void Init()
    {
        foreach (var saveItem in m_saveItems)
        {
            saveItem.SelfToggle.onValueChanged.AddListener((newState) =>
            {
                if (newState)
                {
                    OnSaveClicked(saveItem);
                }
            });
        }
        
        UISaveItem.CurrentSaveItem = m_saveItems[0];
    }

    private void OnSaveClicked(UISaveItem saveItem)
    {
        UISaveItem.CurrentSaveItem = saveItem;
        GameManager.OnCharacterChanged?.Invoke(saveItem.CharacterData);
    }
}