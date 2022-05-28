using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    new private Rigidbody2D rigidbody;
    private Collider2D coll;
    private Animator animator;
    private float inputX, inputY;
    public float stopX, stopY;
    public bool isMove=false;
    private float preinputX = 1;
    private Vector3 rightVec;
    //public SkeletonAnimation sa;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        rightVec = transform.right;
    }

    void Update()
    {

    }
    private void FixedUpdate()
    {
        inputX = Input.GetAxisRaw("Horizontal");//只返回-1，0，1
        inputY = Input.GetAxisRaw("Vertical");
        Vector2 input = (rightVec * inputX + transform.up * inputY).normalized;
        rigidbody.velocity = input * speed;
        //rigidbody.velocity = new Vector2(inputX * speed, inputY * speed);
        if (input != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
            stopX = inputX;
            stopY = inputY;
            if (inputX!=0&&inputX != preinputX)
            {
                transform.Rotate(0f, 180f, 0f);
                preinputX = inputX;
            }
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        animator.SetFloat("InputX", stopX);
        animator.SetFloat("InputY", stopY);
    }
}
