using System;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BagItemInfo : MonoBehaviour
{
    public Button btnClose;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI type;
    public TextMeshProUGUI info;
    public TextMeshProUGUI gold;
    public ScrollRect Status;
    private readonly List<ItemStatusInfo> statusInfos = new();
    private ItemStatusInfo statusInfo;
    private void Awake()
    {
        statusInfo = PrefabMng.GetData("ItemStatusInfo").GetComponent<ItemStatusInfo>();
        btnClose.onClick.AddListener(() => gameObject.SetActive(false));
        EventMng.SetEvent(EventName.OpenItemInfo, (Action<ItemInfo>)((info) =>
        {
            gameObject.SetActive(true);
            SetInfo(info);
        }));
    }

    public void SetInfo(ItemInfo data)
    {
        itemName.text = data.name;
        type.text = data.type.ToString();
        info.text = data.info;
        gold.text = data.gold.ToString();

        foreach (var item in statusInfos) ObjectPool.Put(item);
        statusInfos.Clear();

        // 獲取 ItemStatus 的所有欄位名稱和值
        foreach (FieldInfo field in typeof(ItemStatus).GetFields(BindingFlags.Public | BindingFlags.Instance))
        {
            Debug.LogWarning(field.GetValue(data.status));
            if (field.GetValue(data.status) == null || (int)field.GetValue(data.status) == 0) continue;
            var itemClass = ObjectPool.Get(statusInfo, Status.content);
            itemClass.title.text = PublicFunc.GetChineseName(field.Name);
            itemClass.value.text = field.GetValue(data.status).ToString();
            statusInfos.Add(itemClass);
        }
    }
}