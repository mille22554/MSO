using System.IO;
using UnityEngine;

public class SaveMng
{
    private static readonly string saveDirectoryPath = Path.Combine(Application.persistentDataPath, "Saves");

    // 儲存遊戲數據根據帳號名稱
    public static void SaveGame(string accountName, SaveData save)
    {
        // 確保存檔目錄存在
        if (!Directory.Exists(saveDirectoryPath)) Directory.CreateDirectory(saveDirectoryPath);
        Debug.LogWarning(saveDirectoryPath);

        // 建立存檔路徑，使用帳號名稱作為檔案名
        string saveFilePath = Path.Combine(saveDirectoryPath, accountName + ".json");

        // 將遊戲數據序列化為 JSON 字串
        string jsonData = JsonUtility.ToJson(save, true);

        // 將 JSON 字串寫入帳號對應的存檔檔案
        File.WriteAllText(saveFilePath, jsonData);
        Debug.Log($"Game Data Saved for {accountName}!");
        GameData.save = save;
    }

    // 根據帳號名稱讀取遊戲數據
    public static SaveData LoadGame(string accountName)
    {
        // 構建帳號對應的存檔路徑
        string saveFilePath = Path.Combine(saveDirectoryPath, accountName + ".json");

        // 檢查存檔檔案是否存在
        if (File.Exists(saveFilePath))
        {
            // 從檔案中讀取 JSON 字串
            string jsonData = File.ReadAllText(saveFilePath);

            // 將 JSON 字串反序列化回 SaveData 物件
            SaveData gameData = JsonUtility.FromJson<SaveData>(jsonData);
            Debug.Log($"Game Data Loaded for {accountName}!");
            return gameData;
        }
        else
        {
            Debug.LogWarning($"Save file not found for {accountName}!");
            return null;
        }
    }
}