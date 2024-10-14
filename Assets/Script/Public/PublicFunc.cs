using UnityEngine;

public class PublicFunc
{
    public static byte[] SpriteToBytes(Sprite sprite)
    {
        var t2d = new Texture2D(sprite.texture.width, sprite.texture.height, TextureFormat.RGBA32, false);
        // 使用 byte[] 資料載入 Texture
        t2d.SetPixels(sprite.texture.GetPixels());
        // 重新應用已載入的數據
        t2d.Apply();
        // 從 Texture2D 創建一個新的 Sprite
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
}