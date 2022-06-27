using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[SerializeField]
public enum InputState
{
    Idle,
    Move,
    Attack
}

public class Player : MonoBehaviour
{
    public InputState inputState = InputState.Idle;
    public float hp = 3;
    public GameObject sc;

    public void PlayerDead()
    {
        Collider2D[] cols =  Physics2D.OverlapCircleAll(Vector2.zero, 10).ToArray();
        cols.ToList().ForEach(x => x.gameObject.SetActive(false));
        sc.SetActive(true); // 이거 좀 바꿔야함
        GameManager.instance.gameObject.GetComponent<SpaghettiManager>().SpawnSpaghettiCall();
        
    }
}
