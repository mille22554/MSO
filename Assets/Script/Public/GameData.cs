using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public static SaveData save;
    public static PlayerData PlayerData { get { return save.playerData; } set { save.playerData = value; } }
    public static BagData BagData { get { return save.bagData; } }
    public static string[] version = {
        "_v0.0.2",
        "_v0.0.1"
    };
}
public class SaveData
{
    public PlayerData playerData;
    public BagData bagData = new();
}
public class PlayerData
{
    public string account;
    public string name;
    public byte[] avator;
    public int lv = 1;

    public int nowHp = 100;
    public int nowMp = 50;
    public int nowTp = 100;
    public int nowExp = 0;

    public int maxHp = 100;
    public int maxMp = 50;
    public int maxTp = 100;
    public int maxExp = 10;
    public int APoint = 6;
    public int STR = 1;
    public int VIT = 1;
    public int INT = 1;
    public int AGI = 1;
    public int DEX = 1;
    public int LUK = 1;

    public int ad;
    public int def;
    public int ap;
    public int mdf;
    public int cri;
    public int dcri;
    public int spd;
    public int agl;
    public int acc;
    public int fate;

    public PlayerData(string _account)
    {
        account = _account;
    }
}
public class BagData
{
    public List<ItemInfo> equips = new()
    {
        new ItemInfo
        {
            name = "初始短刀",
            gold = 100,
            type = ItemType.knife,
            status = new(){
                ad = 10,
                spd = -10,
                LUK = 100,
            },
            info = "給新手冒險者使用的最基本的小刀"
        }
    };
}
public class ItemInfo
{
    public string name;
    public int gold;
    public string type;
    public int num;
    public string info;
    public ItemStatus status;

}
public class ItemStatus
{
    public int maxHp;
    public int maxMp;
    public int maxTp;

    public int STR;
    public int VIT;
    public int INT;
    public int AGI;
    public int DEX;
    public int LUK;

    public int ad;
    public int def;
    public int ap;
    public int mdf;
    public int cri;
    public int dcri;
    public int spd;
    public int agl;
    public int acc;
    public int fate;
}
public class ItemType
{
    public const string knife = "短刀";
    public const string material = "素材";
    public const string consumable = "消耗品";
}