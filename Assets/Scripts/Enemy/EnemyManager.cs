using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyManager : MonoBehaviour
{
    public Transform spawner;
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public List<GameObject> enemyBulletPrefabs = new List<GameObject>();

    private List<GameObject> tempList = new List<GameObject>();
    private Sequence tempSeq;

    private WaitForSeconds oneSec = new WaitForSeconds(1f);
    private WaitForSeconds pointFiveSec = new WaitForSeconds(.5f);

    public void Start()
    {
        for(int i =0; i<enemyPrefabs.Count;i++)
        {
            GenericPoolManager<GameObject>.CratePool(enemyPrefabs[i].name, enemyPrefabs[i], this.transform,5);
        }

        for (int i = 0; i < enemyBulletPrefabs.Count; i++)
        {
            GenericPoolManager<GameObject>.CratePool(enemyBulletPrefabs[i].name, enemyBulletPrefabs[i], GameManager.instance.gameObject.transform, 100);
        }

        tempSeq = DOTween.Sequence();

        StartCoroutine(PattenOne());
    }


    public IEnumerator PattenOne()
    {
        yield return null;

        for(int i =0;i<3;i++)
        {
            GameObject a;
            a = GenericPoolManager<GameObject>.GetPool(enemyPrefabs[0].name).GetPoolObject();
            a.SetActive(true);
            a.transform.SetParent(spawner.transform);
            a.transform.position = new Vector3(i < 1 ? -2f : i > 1 ? 2f : 0f, spawner.transform.position.y);
            tempList.Add(a);
        }
        tempSeq.Kill();

        yield return pointFiveSec;

        tempSeq.Append(tempList[0].transform.DOMoveY(1.5f, 1));
        tempSeq.Join(tempList[1].transform.DOMoveY(2f, 1));
        tempSeq.Join(tempList[2].transform.DOMoveY(1.5f, 1));
    }

}
