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

    public void Fire(GameObject bullet, float power)
    {
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(transform.up.y, transform.up.x) * Mathf.Rad2Deg - 90));

        bullet.GetComponentInChildren<SpriteRenderer>().color = sr.color;

        bullet.transform.position = transform.GetComponentInChildren<Transform>().position;
        bullet.gameObject.SetActive(true);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(transform.up * power, ForceMode2D.Impulse);
    }
}
