using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SlimeMove : Slime
{
    [SerializeField] private float realMoveSpeed;
    [SerializeField] private float moveSpeed = 0;
    private Vector2 inputAxis = Vector2.zero;
    private FaceDirection direction = FaceDirection.Right;
    private enum FaceDirection
    {
        Left = -1,
        Right = 1
    }

    protected override void Start()
    {
        base.Start();
        EventManager.StartListening("HorizontalMove", DoMove);
    }

    private void Update()
    {
        // 일단 Velocity로 움직이게 하고 나중엔 AddForce로 가다가 최고속도가 되면 Velocity로 움직이게 수정
        // rb2D.AddForce(transform.forward * moveSpeed * inputAxis.x);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = FaceDirection.Left;
            if (moveSpeed <= realMoveSpeed) moveSpeed += 0.1f;
            rb2D.velocity = new Vector2(-1 * moveSpeed, rb2D.velocity.y);
            gameObject.transform.localScale = new Vector2(1, 1);
            // SpriteRender의 flipX기능은 스프라이트만 바뀌고 collider라던지 다른 부분은 바뀌지 않기 때문에
            // transform의 Scale을 바꾸거나 해야한다.
            // spriteRen.flipX = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
           direction = FaceDirection.Right;
            if (moveSpeed <= realMoveSpeed) moveSpeed += 0.1f;
            rb2D.velocity = new Vector2(1 * moveSpeed, rb2D.velocity.y);
            gameObject.transform.localScale = new Vector2(-1, 1);
            // spriteRen.flipX = true;
        }
        else
        {
            if (direction == FaceDirection.Left)
            {
                moveSpeed = Mathf.Lerp(moveSpeed, 0, Time.deltaTime * 2);
                rb2D.velocity = new Vector2(-1*moveSpeed, rb2D.velocity.y);
            }
            else if (direction == FaceDirection.Right)
            {
                moveSpeed = Mathf.Lerp(moveSpeed, 0, Time.deltaTime * 2);
                rb2D.velocity = new Vector2(1*moveSpeed, rb2D.velocity.y);
            }
        }
        if (moveSpeed < 0.1f) moveSpeed = 0;
    }

    private void FixedUpdate()
    {
        
    }

    private void DoMove(EventParam eventParam)
    {
        inputAxis.x = eventParam.vecParam.x;
    }

    private void OnDestroy()
    {
        EventManager.StopListening("HorizontalMove", DoMove);
    }
}
