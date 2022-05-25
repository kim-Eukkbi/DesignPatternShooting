using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPool<T> where T : Object
{
    private Queue<Object> queue;
    private Transform parent = null;

    private T prefab = null;

    public GenericPool(T prefab, Transform parent, int childCount = 5)
    {
        queue = new Queue<Object>();

        this.prefab = prefab;
        this.parent = parent;

        for (int i = 0; i < childCount; i++)
        {
            CreatePoolObj();
        }
    }

    public GameObject GetPoolObject()
    {
        GameObject result = null;

        if(queue.Count > 0)
        {
            if(!(queue.Peek() as GameObject).activeSelf)
            {
                result = queue.Dequeue() as GameObject;
                queue.Enqueue(result);
            }
            else
            {
                result = CreatePoolObj() as GameObject;
            }
        }
        else
        {
            result = CreatePoolObj() as GameObject;
        }
        return result;
    }

    private T CreatePoolObj()
    {
        T result = MonoBehaviour.Instantiate<T>(prefab, parent);
        queue.Enqueue(result);

        (result as GameObject).SetActive(false);

        return result;
    }
}
