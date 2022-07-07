using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEventManager : MonoBehaviour
{
    private static Dictionary<string, Action<Vector2>> eventDictionary = new Dictionary<string, Action<Vector2>>();

    public static void StartListening(string eventName, Action<Vector2> listener)
    {
        Action<Vector2> thisEvent;
        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent += listener;
            eventDictionary[eventName] = thisEvent;
        }
        else
        {
            eventDictionary.Add(eventName, listener);
        }
    }

    public static void StopListening(string eventName, Action<Vector2> listener)
    {
        Action<Vector2> thisEvent;
        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent -= listener;
            eventDictionary[eventName] = thisEvent;
        }
        else
        {
            eventDictionary.Remove(eventName);
        }
    }

    public static void TriggerEvent(string eventName, Vector2 param)
    {
        Action<Vector2> thisEvent;
        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(param);
        }
    }
}
