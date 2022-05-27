using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Dino : MonoBehaviour
{
    DinoBaseState _state;
    public CharacterController controll;
    public Animator animator;
    public float speed = 6.0F;
    public float AttackWaitTime = 0.8F;//�����������У�ÿ�ι�����Ӳֱʱ��
    public float AttacRetTime = 3.0F;//�����������У�ÿ�ι������º��ð��¾�����
    public void SetDinoState(DinoBaseState newState)
    {
        _state = newState;
    }


    void Start()
    {
        //controll = GetComponent<CharacterController>();
        _state = new StandingState(this);
    }

    public void Update()
    {
        _state.HandleInput();
    }

}
