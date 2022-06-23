using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Command_Child : Enemy
{
    SpriteRenderer sr = null;

    public Enemy_Command parent = null;

    private void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    public override void OnDead()
    {
        gameObject.SetActive(false);
    }

    public override void OnHit()
    {
        hp--;
        base.OnHit();
        if (hp <= 0)
        {
            parent.OnHit();
            OnDead();
        }
    }

    public void Fire(GameObject bullet, float power)
    {
        if (!gameObject.activeSelf)
            return;

        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(transform.up.y, transform.up.x) * Mathf.Rad2Deg - 90));

        bullet.GetComponentInChildren<SpriteRenderer>().color = sr.color;

        bullet.transform.position = transform.GetComponentInChildren<Transform>().position;
        bullet.gameObject.SetActive(true);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(transform.up * power, ForceMode2D.Impulse);
    }

    public IEnumerator FireGuided(GameObject bullet, Transform target, float power)
    {
        if (!gameObject.activeSelf)
            yield break;

        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        bullet.transform.position = transform.GetComponentInChildren<Transform>().position;
        bullet.gameObject.SetActive(true);

        float timer = 0f;
        while (timer <= 3f)
        {
            timer += Time.deltaTime;
            Vector2 dir = (target.position - transform.position).normalized;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90));

            rigid.velocity = Vector2.zero;
            rigid.velocity = bullet.transform.up * power;
            yield return null;
        }
    }
}
