using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCol : MonoBehaviour
{
    public bool isPlayerHit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isPlayerHit)
        {
            if (collision.CompareTag("EnemyBullet"))
            {
                collision.GetComponent<EnemyBullet>().ResetBullet();
                isPlayerHit = true;
            }
        }
    }
}
