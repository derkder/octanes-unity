using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Attacking3State : DinoBaseState
{
    private Dino _Dino;
    public Attacking3State(Dino Dino)
    {
        _Dino = Dino;
        Debug.Log("------------------------Dino in Attacking1State~!（进入攻击三号状态！）");
        Update();
    }

    public void Update()//实现第一击
    {
        _Dino.animator.SetBool("isAttack3", true);
        _Dino.animator.SetBool("isAttack2", false);
    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("get KeyCode.axis!");
            _Dino.SetDinoState(new MovingState(_Dino));
        }
        else _Dino.SetDinoState(new StandingState(_Dino));
    }
}
