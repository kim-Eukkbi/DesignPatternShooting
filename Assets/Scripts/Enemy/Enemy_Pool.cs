using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy_Pool : Enemy
{

    private List<GameObject> bullets = new List<GameObject>();

    public void Start()
    {
        StartCoroutine(PattenOne());
    }


    public override void OnHit()
    {
        hp--;
        base.OnHit();
        if(hp <= 0)
        {
            OnDead();
        }
    }


    public override void OnDead()
    {
        gameObject.SetActive(false);
    }


    public IEnumerator PattenOne()
    {
        yield return new WaitForSeconds(2f);

        for(int i = 10; i > 0; i--)
        {
            GameObject a;
            a = GenericPoolManager<GameObject>.GetPool("Enemy_Pool_Bullet").GetPoolObject();
            a.transform.position = transform.position;
            a.transform.Rotate(new Vector3(0f, 0f, 360 * i / 10 - 90));
            a.transform.DOMove(new Vector3(Mathf.Cos(Mathf.PI * 2 * i / 10) / 1.5f + a.transform.position.x, 
                Mathf.Sin(Mathf.PI * i * 2 / 10) / 1.5f + a.transform.position.y), .2f).SetEase(Ease.Linear);
            a.SetActive(true);
            a.GetComponentInChildren<SpriteRenderer>().DOColor(Color.red,.5f);
            bullets.Add(a);
           yield return new WaitForSeconds(.05f);
        }

        yield return new WaitForSeconds(1f);

        for(int i =0; i< bullets.Count;i++)
        {
            Vector3 dir;
            dir = GameManager.instance.player.position - bullets[i].transform.position;

            bullets[i].GetComponent<Rigidbody2D>().AddForce(dir.normalized * 10,ForceMode2D.Impulse);
        }
    }
}
