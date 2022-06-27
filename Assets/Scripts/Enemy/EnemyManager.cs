using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

public class EnemyManager : MonoBehaviour
{
    DiscoverDiary diary = new DiscoverDiary();

    public Transform spawner;
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public List<GameObject> enemyBulletPrefabs = new List<GameObject>();

    
    private Sequence tempSeq;

    private WaitForSeconds oneSec = new WaitForSeconds(1f);
    private WaitForSeconds pointFiveSec = new WaitForSeconds(.5f);

    public List<GameObject> pattenEnemy = new List<GameObject>();

    private void Awake()
    {
        GenericPoolManager.FlushPool();
    }

    public void Start()
    {
        for (int i = 0; i < enemyPrefabs.Count; i++)
        {
            GenericPoolManager.CratePool(enemyPrefabs[i].name, enemyPrefabs[i], this.transform, 5);
        }

        for (int i = 0; i < enemyBulletPrefabs.Count; i++)
        {
            GenericPoolManager.CratePool(enemyBulletPrefabs[i].name, enemyBulletPrefabs[i], GameManager.instance.gameObject.transform, 100);
        }

        tempSeq = DOTween.Sequence();


        StartCoroutine(PattenTwo());
    }


    public void RemoveEnemy(GameObject gameObject)
    {
        pattenEnemy.Remove(gameObject);
        if(pattenEnemy.Count < 1)
        {
            NextPatten();
        }
    }

    public void NextPatten()
    {
        int r = UnityEngine.Random.Range(0, 2);

        switch(r)
        {
            case 0:
                StartCoroutine(PattenOne());
                break;
            case 1:
                StartCoroutine(PattenTwo());
                break;
        }
    }

    public IEnumerator PattenOne()
    {
        yield return null;
        List<GameObject> tempList = new List<GameObject>();
        for(int i =0;i<3;i++)
        {
            GameObject a;
            a = GenericPoolManager.GetPool<GameObject>(enemyPrefabs[0].name).GetPoolObject();
            a.SetActive(true);
            a.transform.SetParent(spawner.transform);
            a.transform.position = new Vector3(i < 1 ? -2f : i > 1 ? 2f : 0f, spawner.transform.position.y);
            tempList.Add(a);
            pattenEnemy.Add(a);
        }
        tempSeq.Kill();

        yield return pointFiveSec;

        tempSeq.Append(tempList[0].transform.DOMoveY(1.5f, 1));
        tempSeq.Join(tempList[1].transform.DOMoveY(2f, 1));
        tempSeq.Join(tempList[2].transform.DOMoveY(1.5f, 1));
    }

    public IEnumerator PattenTwo()
    {
        yield return new WaitForSeconds(1);

        List<GameObject> tempList = new List<GameObject>();
        for (int i = 0; i < 2; i++)
        {
            GameObject a;
            a = GenericPoolManager.GetPool<GameObject>(enemyPrefabs[1].name).GetPoolObject();
            a.SetActive(true);
            a.transform.SetParent(spawner.transform);
            tempList.Add(a);
            pattenEnemy.Add(a);
        }
        tempSeq.Kill();

        tempList[0].transform.position = new Vector3(-2, spawner.transform.position.y);
        tempList[1].transform.position = new Vector3(2, spawner.transform.position.y);

        yield return pointFiveSec;

        tempSeq.Append(tempList[0].transform.DOMoveY(1.5f, 1));
        tempSeq.Append(tempList[1].transform.DOMoveY(1.5f, 1));

    }



}
