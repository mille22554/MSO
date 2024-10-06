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
    public PlayerData(string _account)
    {
        account = _account;
    }
}