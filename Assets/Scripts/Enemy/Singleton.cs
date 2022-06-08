using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : Enemy
{
    public void Start()
    {
        GameManager.instance.OnBulletHitEnemy.AddListener(OnHit);
    }


    public override void OnHit()
    {
        hp--;
        base.OnHit();
        if(hp <= 0)
        {
            OnDead();
        }
    }


    public override void OnDead()
    {
        gameObject.SetActive(false);
    }
}
