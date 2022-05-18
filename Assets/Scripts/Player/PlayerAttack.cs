using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public List<GameObject> bulletList = new List<GameObject>();
    public float fireDelay;


    private PlayerInput input;


    public void Start()
    {
        input = GetComponent<PlayerInput>();
        StartCoroutine(Fire());
    }


    public IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireDelay);
            if (input.isSpaced)
            {
                Instantiate(bulletList[Random.Range(0, 2)], transform.position, Quaternion.Euler(0,0,90f));
            }
        }
    }

}
