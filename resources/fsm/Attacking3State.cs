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
        Debug.Log("------------------------Dino in Attacking1State~!�����빥������״̬����");
        Update();
    }

    public void Update()//ʵ�ֵ�һ��
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
