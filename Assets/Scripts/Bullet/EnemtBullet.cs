using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemtBullet : MonoBehaviour
{
    public void Update()
    {
        if (transform.position.y <= -7f)
        {
            gameObject.SetActive(false);
        }
    }
}
