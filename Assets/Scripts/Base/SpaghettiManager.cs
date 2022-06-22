using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaghettiManager : MonoBehaviour
{
    public GameObject spaghetti1;
    public GameObject spaghetti2;
    public GameObject spaghetti3;

    public void Start()
    {
        GenericPoolManager.CratePool("sp1", spaghetti1, transform, 5);
        GenericPoolManager.CratePool("sp2", spaghetti2, transform, 5);
        GenericPoolManager.CratePool("sp3", spaghetti3, transform, 5);
    }

    public void SpawnSpaghetti()
    {
        for (int i = 0; i < 5; i++)
        {
            int index = Random.Range(1, 4);
            GameObject a = GenericPoolManager.GetPool<GameObject>("sp" + index).GetPoolObject();
            a.transform.position += new Vector3(0, 15f);
            a.SetActive(true);
        }

        UIManager.Instance.Gameover();
    }
}
