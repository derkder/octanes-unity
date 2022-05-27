using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
public class StandingState : DinoBaseState
{
    private Dino _Dino;
    public StandingState(Dino Dino)
    {
        _Dino = Dino;
        Debug.Log("------------------------Dino in StandingState~!（进入站立状态！）");
        Update();
    }

    public void Update()
    {
        _Dino.animator.SetBool("isWalk", false);
        _Dino.animator.SetBool("isIdle", true);
    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("get KeyCode.axis!");
            _Dino.SetDinoState(new MovingState(_Dino));
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("get KeyCode..LeftControl!");
            _Dino.SetDinoState(new Attacking1State(_Dino));
        }
    }
}
