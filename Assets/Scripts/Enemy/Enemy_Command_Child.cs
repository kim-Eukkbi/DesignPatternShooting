using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Command_Child : Enemy
{
    public Enemy_Command parent = null;

    public override void OnDead()
    {
        gameObject.SetActive(false);
    }

    public void Fire(GameObject bullet, float power)
    {
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg - 90));

        bullet.transform.position = transform.position;
        bullet.gameObject.SetActive(true);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(transform.right * power, ForceMode2D.Impulse);
    }
}
