using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;



[RequireComponent(typeof(CircleCollider2D))]
public abstract class Enemy : MonoBehaviour
{
    public float hp;
    private List<IEnumerator> feedBacks = new List<IEnumerator>();

    private List<SpriteRenderer> childSprites = new List<SpriteRenderer>();
    public virtual void OnHit()
    {
        for (int i = 0; i < feedBacks.Count;i++)
        {
            StopCoroutine(feedBacks[i]);
        }

        feedBacks.Add(FeadBack());

        for (int i = 0; i < feedBacks.Count; i++)
        {
            StartCoroutine(feedBacks[i]);
        }
    }
    public abstract void OnDead();

    public IEnumerator FeadBack()
    {
        print("Hit:" + gameObject.name);
        childSprites = transform.GetComponentsInChildren<SpriteRenderer>().ToList();
        childSprites.ForEach(x => x.material.color = Color.red);
        yield return new WaitForSeconds(.1f);
        childSprites.ForEach(x => x.material.color = Color.white);
    }
}
