using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Attacking2State : DinoBaseState
{
    private Dino _Dino;
    private float time;
    private float backTime;
    public bool canMove;
    private float start;
    public Attacking2State(Dino Dino)
    {
        _Dino = Dino;
        time = _Dino.AttackWaitTime;
        backTime = _Dino.AttacRetTime;
        canMove = false;
        Debug.Log("------------------------Dino in Attacking1State~!（进入攻击二号状态！）");
        Update();
        _Dino.StartCoroutine(OnWaitMethod());
    }

    public void Update()//实现第一击
    {
        _Dino.animator.SetBool("isAttack2", true);
        _Dino.animator.SetBool("isAttack1", false);
    }

    public void HandleInput()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("get KeyCode.axis!");
                _Dino.SetDinoState(new MovingState(_Dino));
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl))//第三连击
            {
                _Dino.SetDinoState(new Attacking3State(_Dino));
            }
            else if(Time.time - start > backTime) _Dino.SetDinoState(new StandingState(_Dino));
        }
    }
    IEnumerator OnWaitMethod()
    {
        yield return new WaitForSeconds(time);
        canMove = true;
        start = Time.time;
    }
}
