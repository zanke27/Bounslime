using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeState : Slime
{
    protected override void Start()
    {
        base.Start();
        EventManager.StartListening("StopState", DoStopState);
    }

    private void Update()
    {
        if (transform.position.y < -10f)
        {
            EventManager.TriggerEvent("ReStart", eventParam);
        }
    }

    private void DoStopState(EventParam eventParam)
    {
        Debug.Log("Time Stop");
        // SlimeMove 스크립트 찾아서 enabled 해보기?
        rb2D.bodyType = RigidbodyType2D.Static;
    }

    private void OnDestroy()
    {
        EventManager.StopListening("StopState", DoStopState);
    }
}
