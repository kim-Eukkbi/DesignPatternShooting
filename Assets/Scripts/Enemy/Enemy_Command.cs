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

        StartCoroutine(Pattern02());
    }

    public override void OnDead()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator Pattern01()
    {
        for (int i = 0; i < 24; i++)
        {
            transform.DORotate(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + (i + 1) * 15), 0.1f);
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
        transform.DOMove(FindObjectOfType<Player>().transform.position + new Vector3(0, 3f), 0.5f);
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                children[i].Fire(bulletPool.GetPoolObject(), 3f);
                yield return new WaitForSeconds(0.1f);
            }

            transform.DORotate(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - 120), 0.2f);
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }

    private IEnumerator Pattern03()
    {
        yield return null;
    }
}
