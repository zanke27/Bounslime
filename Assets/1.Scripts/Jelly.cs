using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    [SerializeField] private int maxJelly = 0;
    [SerializeField] private int nowJelly = 0;
    private EventParam eventParam = new EventParam();

    private void Start()
    {
        EventManager.StartListening("EatJelly", DoEatJelly);
    }

    private void DoEatJelly(EventParam eventParam)
    {
        nowJelly += 1;
        if (maxJelly <= nowJelly)
        {
            EventManager.TriggerEvent("StageClear", eventParam);
        }
    }

    private void OnDestroy()
    {
        EventManager.StopListening("EatJelly", DoEatJelly);
    }
}
