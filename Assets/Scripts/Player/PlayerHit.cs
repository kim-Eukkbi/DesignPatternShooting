using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public PlayerCol pCol;
    public Player p;
    public bool isOnProcess = false;

    void Start()
    {
        pCol = GetComponent<PlayerCol>();
        p = GetComponent<Player>();
    }


    void Update()
    {
        if(pCol.isPlayerHit && !isOnProcess)
        {
            isOnProcess = true;
            StartCoroutine(HitProcess());
        }
    }

    public IEnumerator HitProcess()
    {
        List<SpriteRenderer> childSprites = null;

        p.hp--;

        if(p.hp <= 0)
        {
            p.PlayerDead();
        }

        print("Hit:" + gameObject.name);
        childSprites = transform.GetComponentsInChildren<SpriteRenderer>().ToList();
        childSprites.ForEach(x => x.material.color = Color.red);
        yield return new WaitForSeconds(.1f);
        childSprites.ForEach(x => x.material.color = Color.white);

        yield return new WaitForSeconds(2f);
        isOnProcess = false;
        pCol.isPlayerHit = false;
    }
}
