using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : Enemy
{


    public override void OnHit()
    {
        StopAllCoroutines();
        StartCoroutine(FeadBack());
    }


    public override void OnDead()
    {

    }
}
