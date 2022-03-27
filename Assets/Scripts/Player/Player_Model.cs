using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//动画
public class Player_Model : MonoBehaviour
{
    private Player_Controller player;
    private Animator animator;

    public void Init(Player_Controller player)
    {
        this.player = player;
        animator = GetComponent<Animator>();
    }
    //更新移动参数
    public void UpdateMovePar(float x)
    {
        animator.SetFloat("前后", x);
    }
}
