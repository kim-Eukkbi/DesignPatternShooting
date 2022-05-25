using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenericPoolManager<T> where T : Object
{
    private static Dictionary<string, object> poolDict = new Dictionary<string, object>();

    public static void CratePool(string key, T obj, Transform parent)
    {
        poolDict.Add(key, new GenericPool<T>(obj, parent, 5));
    }

    public static GenericPool<T> GetPool(string key)
    {
        return poolDict[key] as GenericPool<T>;
    }
}
