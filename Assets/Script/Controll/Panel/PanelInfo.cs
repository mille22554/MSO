using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelInfo : MonoBehaviour
{
    public Image avator;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI mp;
    public TextMeshProUGUI tp;
    public TextMeshProUGUI lv;
    public TextMeshProUGUI exp;

    private void Start()
    {
        EventMng.SetEvent(EventName.RefreshInfo, (Action)RefreshInfo);
    }
    public void SetInfo()
    {
        if (GameData.PlayerData.avator == null)
        {
            // avator.sprite = ImageMng.GetData("DefaultAvator");
            GameData.PlayerData.avator = PublicFunc.SpriteToBytes(ImageMng.GetData("DefaultAvator2"));
            var rect = avator.GetComponent<RectTransform>();
            avator.sprite = PublicFunc.BytesToSprite(GameData.PlayerData.avator, rect.rect.width, rect.rect.height);
            SaveMng.SaveGame();
        }
        else
        {
            var rect = avator.GetComponent<RectTransform>();
            avator.sprite = PublicFunc.BytesToSprite(GameData.PlayerData.avator, rect.rect.width, rect.rect.height);
        }
        playerName.text = GameData.PlayerData.name;
        RefreshInfo();
    }
    private void RefreshInfo()
    {
        PublicFunc.RefreshPlayerStatus();
        lv.text = $"LV {GameData.PlayerData.lv}";
        hp.text = $"HP {GameData.PlayerData.nowHp}/{GameData.PlayerData.maxHp}";
        mp.text = $"MP {GameData.PlayerData.nowMp}/{GameData.PlayerData.maxMp}";
        tp.text = $"TP {GameData.PlayerData.nowTp}/{GameData.PlayerData.maxTp}";
        exp.text = $"EXP {GameData.PlayerData.nowExp}/{GameData.PlayerData.maxExp}";
    }
}