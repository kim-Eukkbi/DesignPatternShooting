using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public List<Sprite> bulletSprites = new List<Sprite>();
    public float fireDelay;


    private PlayerInput input;
    public void Start()
    {
        input = GetComponent<PlayerInput>();

        GenericPoolManager<GameObject>.CratePool("Bullet", bulletPrefab, GameObject.Find("BulletParent").transform);

        StartCoroutine(Fire());
    }


    public IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireDelay);
            if (input.isSpaced)
            {
                Transform tr = (GenericPoolManager<GameObject>.GetPool("Bullet").GetPoolObject()).transform;
                tr.GetComponent<SpriteRenderer>().sprite = bulletSprites[Random.Range(0, 2)];
                tr.gameObject.SetActive(true);
                tr.position = transform.position + Vector3.up * .5f;
                tr.rotation = Quaternion.Euler(0, 0, 90f);
            }
        }
    }

}
