using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEatItem : Slime
{
    protected override void Start()
    {
        base.Start();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jelly"))
        {
            Destroy(collision.gameObject);
            EventManager.TriggerEvent("EatJelly", eventParam);
        }
    }
}
