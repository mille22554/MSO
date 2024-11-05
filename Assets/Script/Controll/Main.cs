using System;
using UnityEngine;

public class Main : MonoBehaviour
{
    void Start()
    {
        EventMng.SetEvent(EventName.EnterGame, (Action)EnterGame);

        ObjectPool.Get(PrefabMng.GetData("PanelLogin").GetComponent<PanelLogin>(), gameObject.transform);
    }
    private void EnterGame()
    {
        ObjectPool.Get(PrefabMng.GetData("PageMain").GetComponent<PageMain>(), gameObject.transform);
        ObjectPool.Get(PrefabMng.GetData("PanelButton").GetComponent<PanelButton>(), gameObject.transform);
    }
}