using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void Update()
    {
        transform.position += new Vector3(0, Time.deltaTime * 7);
        if(transform.position.y >= 10f)
        {
            gameObject.SetActive(false);
        }
    }
}
