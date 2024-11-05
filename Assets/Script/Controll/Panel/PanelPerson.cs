using System;
using TMPro;
using UnityEngine;

public class PanelPerson : MonoBehaviour
{
    public TextMeshProUGUI APoint;
    public ModelAPointAdd STR;
    public ModelAPointAdd VIT;
    public ModelAPointAdd AGI;
    public ModelAPointAdd INT;
    public ModelAPointAdd DEX;
    public ModelAPointAdd LUK;
    public TextMeshProUGUI ad;
    public TextMeshProUGUI ap;
    public TextMeshProUGUI def;
    public TextMeshProUGUI mdf;
    public TextMeshProUGUI spd;
    public TextMeshProUGUI acc;

    private void Awake()
    {
        EventMng.SetEvent(EventName.OnPageSwitch, (Action<string>)OnPageSwitch);
        EventMng.SetEvent(EventName.SetPersonInfo, (Action)SetInfo);
    }
    private void OnPageSwitch(string pageName)
    {
        if (pageName == gameObject.name.Replace("(Clone)", ""))
        {
            SetInfo();
            gameObject.SetActive(true);
        }
        else gameObject.SetActive(false);
    }
    public void SetInfo()
    {
        PublicFunc.RefreshPlayerStatus();

        APoint.text = GameData.PlayerData.APoint.ToString();
        STR.value.text = GameData.PlayerData.STR.ToString();
        VIT.value.text = GameData.PlayerData.VIT.ToString();
        AGI.value.text = GameData.PlayerData.AGI.ToString();
        INT.value.text = GameData.PlayerData.INT.ToString();
        DEX.value.text = GameData.PlayerData.DEX.ToString();
        LUK.value.text = GameData.PlayerData.LUK.ToString();
        ad.text = GameData.PlayerData.ad.ToString();
        ap.text = GameData.PlayerData.ap.ToString();
        def.text = GameData.PlayerData.def.ToString();
        mdf.text = GameData.PlayerData.mdf.ToString();
        spd.text = GameData.PlayerData.spd.ToString();
        acc.text = GameData.PlayerData.acc.ToString();
    }
}