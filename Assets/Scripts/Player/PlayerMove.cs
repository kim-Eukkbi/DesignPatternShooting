using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerInput input;
    public float speed = 0f;

    public void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        input.inputAxis = input.inputAxis.normalized * (Time.deltaTime * speed);
        transform.position += (Vector3)input.inputAxis;
    }
}
