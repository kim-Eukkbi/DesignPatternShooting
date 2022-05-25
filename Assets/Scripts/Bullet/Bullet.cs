using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void Update()
    {
        transform.position += new Vector3(0, Time.deltaTime * 7);
        if(transform.position.y >= 7f)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.OnBulletHitEnemy?.Invoke();
        }
        gameObject.SetActive(false);
    }
}
