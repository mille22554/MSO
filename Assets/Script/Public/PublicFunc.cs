using UnityEngine;

public class PublicFunc
{
    public static byte[] SpriteToBytes(Sprite sprite)
    {
        Texture2D t2d;
        if (IsCompressed(sprite.texture.format))
        {
            t2d = new(sprite.texture.width, sprite.texture.height, TextureFormat.RGBA32, false);
            // 使用 byte[] 資料載入 Texture
            t2d.SetPixels(sprite.texture.GetPixels());
            // 重新應用已載入的數據
            t2d.Apply();
        }
        else
        {
            t2d = new(sprite.texture.width, sprite.texture.height, sprite.texture.format, false);
            // 使用 byte[] 資料載入 Texture
            t2d.LoadRawTextureData(sprite.texture.GetRawTextureData());
            // 重新應用已載入的數據
            t2d.Apply();
        }
        return t2d.EncodeToPNG();
    }
    public static Sprite BytesToSprite(byte[] bytes, float width, float height)
    {
        var t2d = new Texture2D((int)width, (int)height);
        // 使用 byte[] 資料載入 Texture
        t2d.LoadImage(bytes);
        // 從 Texture2D 創建一個新的 Sprite
        return Sprite.Create(t2d, new Rect(0, 0, t2d.width, t2d.height), new Vector2(0.5f, 0.5f));
    }
    private static bool IsCompressed(TextureFormat format)
    {
        // 判斷是否為壓縮格式
        return format switch
        {
            TextureFormat.DXT1 or TextureFormat.DXT5 or TextureFormat.PVRTC_RGB2 or TextureFormat.PVRTC_RGBA2 or TextureFormat.ETC_RGB4 or
            TextureFormat.ETC2_RGBA8 => true,
            _ => false,
        };
    }
    public static void RefreshPlayerStatus()
    {
        GameData.PlayerData.maxHp = GameData.PlayerData.VIT * 5 + GameData.PlayerData.STR * 2 + GameData.PlayerData.lv * 10;
        GameData.PlayerData.maxMp = GameData.PlayerData.VIT * 2 + GameData.PlayerData.INT * 2 + GameData.PlayerData.lv * 5;
        GameData.PlayerData.maxExp = GameData.PlayerData.lv * 10;
        GameData.PlayerData.maxTp = GameData.PlayerData.lv + 99;

        if (GameData.PlayerData.nowHp > GameData.PlayerData.maxHp) GameData.PlayerData.nowHp = GameData.PlayerData.maxHp;
        if (GameData.PlayerData.nowMp > GameData.PlayerData.maxMp) GameData.PlayerData.nowMp = GameData.PlayerData.maxMp;

        GameData.PlayerData.ad = GameData.PlayerData.STR / 2 + GameData.PlayerData.lv;
        GameData.PlayerData.ap = GameData.PlayerData.INT / 2 + GameData.PlayerData.lv;
        GameData.PlayerData.def = GameData.PlayerData.VIT / 3 + GameData.PlayerData.STR / 6 + GameData.PlayerData.lv / 2;
        GameData.PlayerData.mdf = GameData.PlayerData.VIT / 3 + GameData.PlayerData.INT / 6 + GameData.PlayerData.lv / 2;
        GameData.PlayerData.cri = GameData.PlayerData.AGI / 2 + GameData.PlayerData.DEX / 5 + GameData.PlayerData.lv;
        GameData.PlayerData.dcri = GameData.PlayerData.AGI / 3 + GameData.PlayerData.DEX / 6 + GameData.PlayerData.lv / 2;
        GameData.PlayerData.spd = GameData.PlayerData.DEX / 5 + GameData.PlayerData.AGI / 10 + GameData.PlayerData.lv / 5 + 100;
        GameData.PlayerData.agl =
            GameData.PlayerData.DEX / 3 + GameData.PlayerData.AGI / 6 + GameData.PlayerData.LUK / 10 + GameData.PlayerData.lv / 3;
        GameData.PlayerData.acc =
            GameData.PlayerData.DEX / 2 + GameData.PlayerData.AGI / 5 + GameData.PlayerData.AGI / 10 + GameData.PlayerData.lv / 2;
    }
    public static string GetChineseName(string EName)
    {
        var CName = "";
        switch (EName)
        {
            case "ad":
                CName = "物理攻擊力";
                break;
            case "def":
                CName = "物理防禦力";
                break;
            case "ap":
                CName = "魔法攻擊力";
                break;
            case "mdf":
                CName = "魔法防禦力";
                break;
            case "cri":
                CName = "會心";
                break;
            case "dcri":
                CName = "會心抗性";
                break;
            case "spd":
                CName = "行動速度";
                break;
            case "agl":
                CName = "迴避";
                break;
            case "acc":
                CName = "命中";
                break;
            case "fate":
                CName = "天命";
                break;
            default:
                return EName;
        }
        return CName;
    }
}