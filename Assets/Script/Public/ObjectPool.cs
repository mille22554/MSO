using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private static readonly Dictionary<Type, List<MonoBehaviour>> itemClasses = new();
    public static T Get<T>(T item, Transform parent) where T : MonoBehaviour
    {
        if (itemClasses.TryGetValue(typeof(T), out var classList))
        {
            if (classList.Count == 0)
            {
                return GameObject.Instantiate(item.gameObject, parent).GetComponent<T>();
            }
            else
            {
                var itemClass = classList[0];
                itemClass.gameObject.SetActive(true);
                classList.RemoveAt(0);
                return (T)itemClass;
            }
        }
        else
        {
            var itemClass = GameObject.Instantiate(item.gameObject, parent).GetComponent<T>();
            itemClasses.Add(typeof(T), new() { });
            return itemClass;
        }
    }
    public static void Put<T>(T item) where T : MonoBehaviour
    {
        item.gameObject.SetActive(false);
        if (itemClasses.TryGetValue(typeof(T), out var classList)) classList.Add(item);
        else itemClasses.Add(typeof(T), new() { item });
    }
    public static void Clear<T>(T type)
    {
        itemClasses.Remove(typeof(T));
    }
    public static void ClearAll()
    {
        itemClasses.Clear();
    }
}