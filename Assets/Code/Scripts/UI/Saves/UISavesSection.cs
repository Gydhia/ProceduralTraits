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
    }

    private void OnSaveClicked(UISaveItem saveItem)
    {
        Debug.Log("Clicked on save: " + saveItem);
    }
}
