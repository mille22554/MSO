using UnityEngine;

public class GameData
{
    public static SaveData save;
    public static string[] version = {
        "_v0.0.1"
    };
}
public class SaveData
{
    public PlayerData playerData;
}
public class PlayerData
{
    public string account;
    public string name;
    public PlayerData(string _account) { account = _account; }
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
}