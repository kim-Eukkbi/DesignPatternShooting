using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenericPoolManager
{
    private static Dictionary<string, object> poolDict = new Dictionary<string, object>();

    public static void CratePool(Object obj, Transform parent)
    {
        poolDict.Add(obj.GetType().ToString(), new GenericPool<Object>(obj, parent, 5));
    }

    public static GenericPool<Object> GetPool<T>(object obj)
    {
        return poolDict[obj.GetType().ToString()] as GenericPool<Object>;
    }
}
