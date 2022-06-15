using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenericPoolManager
{
    private static Dictionary<string, object> poolDict = new Dictionary<string, object>();

    public static void CratePool<T>(string key, T obj, Transform parent, int count) where T : Object
    {
        poolDict.Add(key, new GenericPool<T>(obj, parent, count));
    }

    public static GenericPool<T> GetPool<T>(string key) where T : Object
    {
        return poolDict[key] as GenericPool<T>;
    }
}
