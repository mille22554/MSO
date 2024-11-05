using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelBag : MonoBehaviour
{
    public Toggle btnEquip;
    public Toggle btnMaterial;
    public Toggle btnConsumable;
    public ScrollRect sr;
    public BagItemInfo bagItemInfo;
    private string lastType = "btnEquip";
    private BagItem bagItem;
    private readonly List<BagItem> bagItems = new();

    private void Awake()
    {
        EventMng.SetEvent(EventName.OnPageSwitch, (Action<string>)OnPageSwitch);
        bagItem = PrefabMng.GetData("BagItem").GetComponent<BagItem>();

        btnEquip.onValueChanged.AddListener(OnSwitchType);
        btnMaterial.onValueChanged.AddListener(OnSwitchType);
        btnConsumable.onValueChanged.AddListener(OnSwitchType);
    }
    private void OnPageSwitch(string pageName)
    {
        if (pageName == gameObject.name.Replace("(Clone)", ""))
        {
            gameObject.SetActive(true);
        }
        else gameObject.SetActive(false);
    }
    public void SetInfo()
    {
        bagItemInfo.gameObject.SetActive(false);
        SetList(lastType);
    }
    private void OnSwitchType(bool e)
    {
        var target = EventSystem.current.currentSelectedGameObject.name;
        if (target == lastType) return;
        lastType = target;
        SetList(target);
    }
    private void SetList(string type)
    {
        foreach (var item in bagItems) ObjectPool.Put(item);
        bagItems.Clear();

        switch (type)
        {
            case "btnEquip":
                // for (int i = 0; i < 30; i++)
                foreach (var equipInfo in GameData.BagData.equips)
                {
                    var itemClass = ObjectPool.Get(bagItem, sr.content);
                    bagItems.Add(itemClass);
                    itemClass.SetInfo(equipInfo);
                };
                break;
            case "btnMaterial":
                break;
            case "btnConsumable":
                break;
        }
    }
}