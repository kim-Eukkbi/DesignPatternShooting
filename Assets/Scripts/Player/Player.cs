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

}
