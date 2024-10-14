using System.Collections.Generic;
using UnityEngine;

public class PrefabMng
{
    private static readonly Dictionary<string, GameObject> datas = new();
    static PrefabMng()
    {
        var prefabDatas = Resources.LoadAll<GameObject>("Prefab");
        foreach (var data in prefabDatas) datas.Add(data.name, data);
    }
    public static GameObject GetData(string dataName)
    {
        return datas.TryGetValue(dataName, out var data) ? data : null;
    }
}
public class ImageMng
{
    private static readonly Dictionary<string, Sprite> datas = new();
    static ImageMng()
    {
        var imageDatas = Resources.LoadAll<Sprite>("Image");
        foreach (var data in imageDatas) datas.Add(data.name, data);
    }
    public static Sprite GetData(string dataName)
    {
        return datas.TryGetValue(dataName, out var data) ? data : null;
    }
}