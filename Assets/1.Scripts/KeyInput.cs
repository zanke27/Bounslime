using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{
    private Vector2 inputAxis = Vector2.zero;
    private EventParam eventParam = new EventParam();

    private void Start()
    {
        eventParam.vecParam = Vector2.zero;
    }

    private void Update()
    {
        inputAxis.x = Input.GetAxis("Horizontal");
        inputAxis.y = Input.GetAxis("Vertical");
        eventParam.vecParam = inputAxis;

        EventManager.TriggerEvent("HorizontalMove", eventParam);

        if (Input.GetKeyDown(KeyCode.R)) EventManager.TriggerEvent("ReStart", eventParam);
    }
}
