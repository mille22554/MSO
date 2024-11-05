using System;
using UnityEngine;

public class PanelHome : MonoBehaviour
{
    private void Awake()
    {
        EventMng.SetEvent(EventName.OnPageSwitch, (Action<string>)OnPageSwitch);
    }
    private void OnPageSwitch(string pageName)
    {
        if (pageName == gameObject.name.Replace("(Clone)", ""))
        {
            gameObject.SetActive(true);
        }
        else gameObject.SetActive(false);
    }
}