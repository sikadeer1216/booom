using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : StateBase<PlayerState>
{
    public Player_Controller player;
    private float moveSpeed = 100;
    private float min_Speed = 100;
    private float max_Speed = 300;
    private float downTime = 0;     //判断是否已经移动2s
    private float maxTime = 2;

    private float runTransition = 0;    //动画过渡时间
    private bool isRun
    {
        get
        {
            bool temp = false;
            if (player.input.Horizontal != 0)
            {
                downTime += Time.deltaTime;
                if (moveSpeed < max_Speed + 1 && downTime > maxTime)
                {
                    temp = true;
                    moveSpeed = max_Speed;
                    //Debug.Log(moveSpeed);
                }
            }
            else
            {
                temp = false;
                downTime = 0;       //计时归零
                moveSpeed = min_Speed;  //速度回到初值
            }
            return temp;
        }
    }
    public override void Init(FSMController<PlayerState> Controller, PlayerState stateType)
    {
        base.Init(Controller, stateType);
        player = Controller as Player_Controller;
    }

    public override void OnEnter()
    {
        
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
        float h = player.input.Horizontal;
        if (h == 1)
        {
            if (isRun && runTransition < 1) runTransition += Time.deltaTime;

        }
        if (h == -1)
        {
            if (isRun && runTransition > -1) runTransition -= Time.deltaTime;

        }
        if(h == 0 )
        {
            if (runTransition > 0) runTransition -= Time.deltaTime;
            if (runTransition < 0) runTransition += Time.deltaTime;
            if (runTransition < 0.01 && runTransition > -0.01) runTransition = 0;
            //if (runTransition < 0.01f && runTransition > -0.01f) runTransition = 0;
        }
        Move(h + runTransition);
    }

    private void Move(float h)
    {
        if (h != 0)
        {
            
            Vector3 dir = new Vector3(h, 0, 0);
            Quaternion targetQ = Quaternion.LookRotation(dir, Vector3.up);
            player.transform.rotation = targetQ;
            player.characterController.SimpleMove(dir * Time.deltaTime * moveSpeed);
        }
        player.model.UpdateMovePar(h);
    }

}
