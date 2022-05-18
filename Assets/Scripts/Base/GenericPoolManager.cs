using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenericPoolManager
{
    private static Dictionary<string, GenericPool<MonoBehaviour>> poolDict = new Dictionary<string, GenericPool<MonoBehaviour>>();

}
