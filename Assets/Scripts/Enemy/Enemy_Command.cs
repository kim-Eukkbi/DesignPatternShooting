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

    public List<Enemy_Command_Child> children = new List<Enemy_Command_Child>();

    private void Awake()
    {
        gameObject.tag = "Enemy";
    }

    private void Start()
    {
        bulletParent = GameObject.Find("BulletParent").transform;

        if(!GenericPoolManager.HasKey(poolKey))
        GenericPoolManager.CratePool(poolKey, bullet, bulletParent, 5);

        bulletPool = GenericPoolManager.GetPool<GameObject>(poolKey);

        if(children.Count < 1)
        {
            foreach (var item in GetComponentsInChildren<Enemy_Command_Child>())
            {
                item.parent = this;
                children.Add(item);
            }
        }
        else
        {
            children.ForEach(item =>
            {
                item.gameObject.SetActive(true);
            });
        }

        StartCoroutine(PickPatten());
    }


    public override void OnHit()
    {
        Debug.Log(children.FindAll(item => item.gameObject.activeSelf).Count < 1);
        if (children.FindAll(item => item.gameObject.activeSelf).Count < 1)
        {
            OnDead();
            
        }
    }

    public IEnumerator PickPatten()
    {
        yield return new WaitForSeconds(2.5f);
        int pattern;
        while (true)
        {
            pattern = Random.Range(0, 3);
            if (children.FindAll(item => item.gameObject.activeSelf).Count < 1)
            {
                OnDead();
                yield break;
            }

            if (pattern == 0)
            {
                StartCoroutine(Pattern01());
            }
            else if (pattern == 1)
            {
                StartCoroutine(Pattern02());
            }
            else
            {
                StartCoroutine(Pattern03());
            }

            yield return new WaitForSeconds(Random.Range(5, 8));
        }
    }

    public override void OnDead()
    {
        gameObject.SetActive(false);
        GameManager.instance.GetComponent<EnemyManager>().RemoveEnemy(gameObject);
    }

    private IEnumerator Pattern01()
    {
        if (children.FindAll(item => item.gameObject.activeSelf).Count < 1)
        {
            OnDead();
            yield break;
        }

        for (int i = 0; i < children.FindAll(item => item.gameObject.activeSelf).Count * 8; i++)
        {
            transform.DORotate(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + (i + 1) * 15), 0.1f);
            yield return new WaitForSeconds(0.1f);
            foreach (var item in children.FindAll(item => item.gameObject.activeSelf))
            {
                item.Fire(bulletPool.GetPoolObject(), 3f);
            }
        }

        yield return null;
    }

    private IEnumerator Pattern02()
    {
        if (children.FindAll(item => item.gameObject.activeSelf).Count < 1)
        {
            OnDead();
            yield break;
        }

        transform.DOMove(FindObjectOfType<Player>().transform.position + new Vector3(0, 3f), 0.5f);
        yield return new WaitForSeconds(0.5f);

        List<Enemy_Command_Child> activeChildren = children.FindAll(item => item.gameObject.activeSelf);
        for (int i = 0; i < activeChildren.Count; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                activeChildren[i].Fire(bulletPool.GetPoolObject(), 3f);
                yield return new WaitForSeconds(0.1f);
            }

            transform.DORotate(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - (360f / activeChildren.Count)), 0.2f);
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }

    private IEnumerator Pattern03()
    {
        if (children.FindAll(item => item.gameObject.activeSelf).Count < 1)
        {
            OnDead();
            yield break;
        }

        for (int j = 0; j < 6; j++)
        {
            StartCoroutine(children.FindAll(item => item.gameObject.activeSelf)[0].FireGuided(bulletPool.GetPoolObject(), FindObjectOfType<Player>().transform, 5f));
            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }
}
