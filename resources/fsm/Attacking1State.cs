using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Attacking1State : DinoBaseState
{
    private Dino _Dino;
    private float time;
    private float backTime;
    private bool canMove;
    private float start;
    public Attacking1State(Dino Dino)
    {
        _Dino = Dino;
        time = _Dino.AttackWaitTime; //Ӳֱʱ��
        backTime = _Dino.AttacRetTime;//���º��ð��¾�����
        canMove = false;
        Debug.Log("------------------------Dino in Attacking1State~!�����빥��һ��״̬����");
        Update();
        _Dino.StartCoroutine(OnWaitMethod());
        //��Ϊ����û�м̳�monobehavior�࣬����Э�̷����ôӱ�ĵط���
    }

    public void Update()//ʵ�ֵ�һ��
    {
        _Dino.animator.SetBool("isAttack1", true);
    }

    public void HandleInput()//�����������״̬ÿ֡��Ҫ����
    {
        if(canMove)//Ӳֱ����
        {
            Debug.Log("Ӳֱ����");
            if (Input.GetKeyDown(KeyCode.LeftControl))//�ڶ�����
            {
                _Dino.SetDinoState(new Attacking2State(_Dino));
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("get KeyCode.axis!");
                _Dino.SetDinoState(new MovingState(_Dino));
            }
            else if(Time.time-start> backTime) _Dino.SetDinoState(new StandingState(_Dino));
        }
    }
    IEnumerator OnWaitMethod()
    {
        yield return new WaitForSeconds(time);
        canMove=true;
        start = Time.time;
    }
    //����ֻҪ�ڸ���ʱ���ڰ������ͺ�
    //������һ��attack֮���3s��һ֡���˹�������
}