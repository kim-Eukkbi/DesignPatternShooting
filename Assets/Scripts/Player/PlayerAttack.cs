using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public List<GameObject> bulletList = new List<GameObject>();
    public float fireDelay;


    private PlayerInput input;

    List<string> bulletKeys = new List<string>();


    public void Start()
    {
        input = GetComponent<PlayerInput>();

        bulletKeys.Add("Bullet0");
        bulletKeys.Add("Bullet1");

        GenericPoolManager.CratePool(bulletKeys[0], bulletList[0], GameObject.Find("BulletParent").transform);
        GenericPoolManager.CratePool(bulletKeys[1], bulletList[1], GameObject.Find("BulletParent").transform);


        StartCoroutine(Fire());
    }


    public IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireDelay);
            if (input.isSpaced)
            {
                Transform tr = (GenericPoolManager.GetPool<GameObject>(bulletKeys[Random.Range(0, 2)]).GetPoolObject() as GameObject).transform;
                tr.position = transform.position;
                tr.rotation = Quaternion.Euler(0, 0, 90f);
            }
        }
    }

}
