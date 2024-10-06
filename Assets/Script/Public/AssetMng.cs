using System.Collections.Generic;
using UnityEngine;

public class PrefabMng
{
    private static readonly Dictionary<string, object> datas = new();
    static PrefabMng()
    {
        var prefabDatas = Resources.LoadAll<GameObject>("Prefab");
        foreach (var data in prefabDatas) datas.Add(data.name, data);
    }
    public static object GetData(string dataName)
    {
        return datas.TryGetValue(dataName, out var data) ? data : null;
    }
}