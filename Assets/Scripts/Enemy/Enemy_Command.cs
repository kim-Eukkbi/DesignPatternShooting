using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy_Command : Enemy
{
    [SerializeField] GameObject bullet = null;

    string poolKey = "Command_Bullet";

    Transform bulletParent = null;

    GenericPool<GameObject> bulletPool = null;

    List<Enemy_Command_Child> children = new List<Enemy_Command_Child>();

    private void Awake()
    {
        gameObject.tag = "Enemy";
    }

    private void Start()
    {
        bulletParent = GameObject.Find("BulletParent").transform;
        GenericPoolManager.CratePool(poolKey, bullet, bulletParent, 30);
        bulletPool = GenericPoolManager.GetPool<GameObject>(poolKey);

        foreach (var item in GetComponentsInChildren<Enemy_Command_Child>())
        {
            item.parent = this;
            children.Add(item);
        }

        StartCoroutine(Pattern01());
    }

    public override void OnDead()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator Pattern01()
    {
        for (int i = 0; i < 24; i++)
        {
            transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, 60 + (i + 1) * 15), 0.1f);
            yield return new WaitForSeconds(0.1f);
            foreach (var item in children)
            {
                item.Fire(bulletPool.GetPoolObject(), 3f);
            }
        }

        yield return null;
    }

    private IEnumerator Pattern02()
    {
        yield return null;
    }

    private IEnumerator Pattern03()
    {
        yield return null;
    }
}
