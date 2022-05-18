using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    private SpriteRenderer backGround;

    [SerializeField]
    private Vector2 offset;

    [SerializeField]
    private float speed = 0f;

    public void Start()
    {
        offset = Vector2.zero;
        backGround = GetComponent<SpriteRenderer>();
        offset = backGround.material.GetTextureOffset("_MainTex");
    }

    public void Update()
    {
        offset += new Vector2(0, Time.deltaTime * speed);
        backGround.material.SetTextureOffset("_MainTex", offset);
    }
}
