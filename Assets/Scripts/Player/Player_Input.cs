using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input
{
    private KeyCode jumpKeyCode = KeyCode.Space;
    public float Horizontal { get => Input.GetAxis("Horizontal"); }

    //按键持续按下状态
    public bool GetKey(KeyCode key)
    {
        return Input.GetKey(key);
    }
    //按键按下瞬间
    public bool GetKeyDown(KeyCode key)
    {
        return GetKeyDown(key);
    }
    //获取当前jump按键是否按下
    public bool GetJumpKey()
    {
        return GetKeyDown(jumpKeyCode);
    }
}
