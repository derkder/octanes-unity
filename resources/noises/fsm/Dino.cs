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
    public float AttackWaitTime = 0.8F;//三连击过程中，每次攻击的硬直时间
    public float AttacRetTime = 3.0F;//三连击过程中，每次攻击按下后多久按下就算数
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
