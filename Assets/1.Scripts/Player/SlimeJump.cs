using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeJump : Slime
{
    [SerializeField] private float jumpPower = 10f;
    public LayerMask Ground;

    private void Awake()
    {
        EventManager.StartListening("ReachToGround", DoJump);
    }

    protected override void Start()
    {
        base.Start();
    }

    private void FixedUpdate()
    {
        /*
        RaycastHit2D[] raycastHit2Ds;
        Debug.DrawRay(transform.position, new Vector2(0, -0.55f), Color.green);

        raycastHit2Ds = Physics2D.RaycastAll(transform.position, Vector2.down, 0.55f);
        */
        

        Collider2D[] colliderHit2Ds = Physics2D.OverlapBoxAll(transform.position,
            new Vector2(0.8f, 1), 0, Ground);

        for (int i = 0; i < colliderHit2Ds.Length; i++)
        {
            Collider2D hit = colliderHit2Ds[i];

            if (hit.CompareTag("Ground"))
            {
                EventManager.TriggerEvent("ReachToGround", eventParam);
            }
        }
        
    }

    private void DoJump(EventParam eventParam)
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpPower);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("ReachToGround", DoJump);
    }
}
