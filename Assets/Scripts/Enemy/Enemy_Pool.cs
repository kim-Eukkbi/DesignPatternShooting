using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy_Pool : Enemy
{
    public void Start()
    {
        StartCoroutine(PickPatten());
    }


    public override void OnHit()
    {
        hp--;
        base.OnHit();
        if (hp <= 0)
        {
            OnDead();
        }
    }


    public override void OnDead()
    {
        gameObject.SetActive(false);
    }

    public IEnumerator PickPatten()
    {
        yield return new WaitForSeconds(2.5f);
        int patten;
        while (true)
        {
            patten = Random.Range(0, 2);


            if(patten == 0)
            {
                StartCoroutine(PattenOne(Random.Range(3, 16), 0f));
            }
            else
            {
                StartCoroutine(PattenTwo(Random.Range(1, 21), 0f));
            }
            
            yield return new WaitForSeconds(3f);
        }
    }


    public IEnumerator PattenOne(int count,float delay)
    {
        yield return new WaitForSeconds(delay);
        List<GameObject> bullets = new List<GameObject>();

        for (int i = count; i > 0; i--)
        {
            GameObject a;
            a = GenericPoolManager.GetPool<GameObject>("Enemy_Pool_Bullet").GetPoolObject();
            a.transform.position = transform.position;
            a.transform.Rotate(new Vector3(0f, 0f, 360 * i / count - 90));
            a.transform.DOMove(new Vector3(Mathf.Cos(Mathf.PI * 2 * i / count) / 1.5f + a.transform.position.x,
                Mathf.Sin(Mathf.PI * i * 2 / count) / 1.5f + a.transform.position.y), .2f).SetEase(Ease.Linear);
            a.SetActive(true);
            bullets.Add(a);
            yield return new WaitForSeconds(.05f);
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < bullets.Count; i++)
        {
            Vector3 dir;
            dir = GameManager.instance.player.position - bullets[i].transform.position;

            bullets[i].GetComponent<Rigidbody2D>().AddForce(dir.normalized * 7, ForceMode2D.Impulse);
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < bullets.Count; i++)
        {
            bullets[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        }

        yield return null;

        for (int i = 0; i < bullets.Count; i++)
        {
            bullets[i].GetComponent<Rigidbody2D>().AddForce((GameManager.instance.player.position - bullets[i].transform.position).normalized * 10, ForceMode2D.Impulse);
        }

        yield return new WaitForSeconds(2f);

        for (int i = 0; i < bullets.Count; i++)
        {
            bullets[i].SetActive(false);
        }

        bullets.Clear();
    }

    public IEnumerator PattenTwo(int count, float delay)
    {

        yield return new WaitForSeconds(delay);
        List<GameObject> bullets = new List<GameObject>();

        for (int i = 0; i < count; i++)
        {
            GameObject bullet;
            Vector2 dir;
            float a = 120f;
            float angle = a / count;
            float r = 270f;

            bullet = GenericPoolManager.GetPool<GameObject>("Enemy_Pool_Bullet").GetPoolObject();

            dir.x = Mathf.Cos((angle * i + r + angle / 2 - a / 2) * Mathf.Deg2Rad) / 1.5f;
            dir.y = Mathf.Sin((angle * i + r + angle / 2 - a / 2) * Mathf.Deg2Rad) / 1.5f;

            bullet.transform.position = new Vector3(dir.x + transform.position.x, dir.y + transform.position.y);
            bullet.transform.Rotate(new Vector3(0f, 0f, 120 * i / count + count + -(count - 10)));
            bullet.GetComponent<EnemyBullet>().dir = dir;
            bullet.SetActive(true);
            bullets.Add(bullet);
        }

        yield return null;

        for (int i = 0; i < bullets.Count; i++)
        {
            bullets[i].GetComponent<Rigidbody2D>().AddForce(bullets[i].GetComponent<EnemyBullet>().dir * 5, ForceMode2D.Impulse);
        }


        bullets.Clear();
    }

}
