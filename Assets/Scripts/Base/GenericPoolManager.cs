using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenericPoolManager
{
    private static Dictionary<string, object> poolDict = new Dictionary<string, object>();

    public static void CratePool(string key, Object obj, Transform parent)
    {
        poolDict.Add(key, new GenericPool<Object>(obj, parent, 5));
    }

    public static GenericPool<Object> GetPool<T>(string key)
    {
        return poolDict[key] as GenericPool<Object>;
    }
}
