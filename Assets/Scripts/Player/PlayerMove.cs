using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerInput input;
    public Vector2 clampAreaMIN;
    public Vector2 clampAreaMAX;
    public float speed = 0f;
    public float dashSpeed = 0f;

    public void Start()
    {
        transform.position = new Vector3(0, -3.5f);
        input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if(input.isShifted)
            input.inputAxis = input.inputAxis.normalized * (Time.deltaTime * dashSpeed);
        else
            input.inputAxis = input.inputAxis.normalized * (Time.deltaTime * speed);

        transform.position += (Vector3)input.inputAxis;

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, clampAreaMIN.x, clampAreaMAX.x),
            Mathf.Clamp(transform.position.y, clampAreaMIN.y, clampAreaMAX.y));
    }
}
