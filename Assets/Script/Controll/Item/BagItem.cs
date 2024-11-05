using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BagItem : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI value;
    private Button btnInfo;
    private ItemInfo info;

    private void Awake()
    {
        btnInfo = gameObject.GetComponent<Button>();
        btnInfo.onClick.AddListener(() => EventMng.EmitEvent(EventName.OpenItemInfo, info));
    }
    public void SetInfo(ItemInfo data)
    {
        info = data;
        title.text = data.name;
        switch (data.type)
        {
            case ItemType.knife:
                value.text = $"AD {data.status.ad}";
                break;
            case ItemType.material:
            case ItemType.consumable:
                value.text = $"x {data.num}";
                break;
        }
    }
}