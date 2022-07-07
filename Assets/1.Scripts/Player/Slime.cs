using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    protected Rigidbody2D rb2D;
    protected EventParam eventParam = new EventParam();
    protected virtual void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
}
