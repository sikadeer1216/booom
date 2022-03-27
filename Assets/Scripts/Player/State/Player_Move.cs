using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : StateBase
{
    public Player_Controller player;
    private float moveSpeed = 90;
    public override void Init(FSMController Controller, Enum stateType)
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
        Move(h);
    }

    private void Move(float h)
    {
        if (h != 0)
        {
            Vector3 dir = new Vector3(h, 0, 0);
            Quaternion targetQ = Quaternion.LookRotation(dir, Vector3.up);
            player.transform.rotation = targetQ;
            player.characterController.SimpleMove(dir * Time.deltaTime * moveSpeed);

            player.model.UpdateMovePar(h);
        }
    }
}
