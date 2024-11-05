using System;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModelAPointAdd : MonoBehaviour
{
    public TextMeshProUGUI value;
    public Button btnAdd;
    public Image icon;

    private void Awake()
    {
        btnAdd.onClick.AddListener(() =>
        {
            // 取得類型
            Type type = typeof(PlayerData);

            // 使用反射來存取欄位的值
            FieldInfo fieldInfo = type.GetField(gameObject.name, BindingFlags.Public | BindingFlags.Instance);

            // 取得欄位的值
            fieldInfo.SetValue(GameData.PlayerData, (int)fieldInfo.GetValue(GameData.PlayerData) + 1);
            value.text = fieldInfo.GetValue(GameData.PlayerData).ToString();
            GameData.PlayerData.APoint--;
            EventMng.EmitEvent(EventName.SetModelAPointAddInteractable, GameData.PlayerData.APoint != 0);
            EventMng.EmitEvent(EventName.SetPersonInfo);
            SaveMng.SaveGame();
        });

        EventMng.SetEvent(EventName.SetModelAPointAddInteractable, (Action<bool>)((isOpen) =>
        {
            btnAdd.interactable = isOpen;
            if (isOpen) icon.color = Color.white;
            else icon.color = new Color(200, 200, 200, 0.5f);
        }));
    }
}