using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 inputAxis;
    public bool isShifted = false;
    public bool isSpaced = false;
    public bool isControled = false;

    public void Start()
    {
        inputAxis = Vector2.zero;
    }

    public void Update()
    {
        inputAxis.x = Input.GetAxisRaw("Horizontal");
        inputAxis.y = Input.GetAxisRaw("Vertical");

        isShifted = false;
        isSpaced = false;
        isControled = false;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isShifted = true;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            isControled = true;
        }


        if (Input.GetKey(KeyCode.Space))
        {
            isSpaced = true;
        }
    }
}
