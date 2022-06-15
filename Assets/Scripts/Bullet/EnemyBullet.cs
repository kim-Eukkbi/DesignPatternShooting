using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Vector2 dir;

    public void Update()
    {
        if (transform.position.y <= -7f || transform.position.y >= 7f)
        {
            ResetBullet();
        }

        if (transform.position.x <= -5f || transform.position.x >= 5f)
        {
            ResetBullet();
        }
    }

    public void ResetBullet()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.SetActive(false);
    }
}
