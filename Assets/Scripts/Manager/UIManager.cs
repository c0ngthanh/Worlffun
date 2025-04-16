using System;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public void CreateUI(string uiName)
    {
        Transform uiTransform = transform.Find(uiName);
        if(uiTransform == null)
        {
            GameObject uiPrefab = Resources.Load<GameObject>("UI/" + uiName);
            if (uiPrefab != null)
            {
                GameObject uiInstance = Instantiate(uiPrefab, transform);
                uiInstance.name = uiName;
                // uiInstance.transform.SetParent(transform, false);
                uiInstance.SetActive(true);
            }
        }
        else
        {
            if(uiTransform.gameObject.activeSelf == false)
            {
                uiTransform.gameObject.SetActive(true);
            }
        }
    }

    internal void HideUI(string uiName)
    {
        Transform uiTransform = transform.Find(uiName);
        if (uiTransform != null)
        {
            uiTransform.gameObject.SetActive(false);
        }
    }
}
