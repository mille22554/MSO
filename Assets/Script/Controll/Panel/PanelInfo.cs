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
        if (GameData.save.playerData.avator == null)
        {
            // avator.sprite = ImageMng.GetData("DefaultAvator");
            GameData.save.playerData.avator = PublicFunc.SpriteToBytes(ImageMng.GetData("DefaultAvator2"));
            var rect = avator.GetComponent<RectTransform>();
            avator.sprite = PublicFunc.BytesToSprite(GameData.save.playerData.avator, rect.rect.width, rect.rect.height);
            SaveMng.SaveGame();
        }
        else
        {
            var rect = avator.GetComponent<RectTransform>();
            avator.sprite = PublicFunc.BytesToSprite(GameData.save.playerData.avator, rect.rect.width, rect.rect.height);
        }
        playerName.text = GameData.save.playerData.name;
        RefreshInfo();
    }
    private void RefreshInfo()
    {
        lv.text = $"LV {GameData.save.playerData.lv}";
        hp.text = $"HP {GameData.save.playerData.nowHp}/{GameData.save.playerData.maxHp}";
        mp.text = $"MP {GameData.save.playerData.nowMp}/{GameData.save.playerData.maxMp}";
        tp.text = $"TP {GameData.save.playerData.nowTp}/{GameData.save.playerData.maxTp}";
        exp.text = $"EXP {GameData.save.playerData.nowExp}/{GameData.save.playerData.maxExp}";
    }
}