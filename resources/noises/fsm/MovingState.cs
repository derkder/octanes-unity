using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class MovingState : DinoBaseState
{
    private Dino _Dino;
    private Vector3 moveDirection = Vector3.zero;

    public MovingState(Dino Dino)//�൱��start�˴��,��Ψһ��ԭ�����ɹ��ĵط���
    {
        _Dino = Dino;
        Debug.Log("------------------------Dino in MovingState~!�������ƶ�״̬����");
        Update();
    }

    public void Update()//ִ���߼�д����
    {
        _Dino.animator.SetBool("isIdle", false);
        _Dino.animator.SetBool("isWalk", true);
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = _Dino.transform.TransformDirection(moveDirection);
        moveDirection *= _Dino.speed;
        _Dino.controll.Move(moveDirection * Time.deltaTime);
    }

    public void HandleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))//ֵ�������˲��ö�������
        {
            Update();
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("get KeyCode.LeftControl!");
            _Dino.SetDinoState(new Attacking1State(_Dino));
        }
        else
        {
            _Dino.SetDinoState(new StandingState(_Dino));
        }
    }
}
