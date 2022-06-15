using System.Collections;
using System.Collections.Generic;
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


    public void PlayerDead()
    {

    }
}
