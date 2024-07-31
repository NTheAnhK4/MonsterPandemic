using System;

using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class EventDispatcher : ComponentBehavior
{
    private static EventDispatcher instance;
    private Dictionary<EventID, Action<Object>> eventManager = new Dictionary<EventID, Action<object>>();
    public static EventDispatcher Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singletonObject = new GameObject();
                instance = singletonObject.AddComponent<EventDispatcher>();
                singletonObject.name = "EventDispatcher (Singleton)";
            }

            return instance;
        }
    }

    protected override void Awake()
    {
        if (instance != null && instance.GetInstanceID() != this.GetInstanceID())
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void AddListener(EventID eventID, Action<Object> callback)
    {
        if (eventManager.ContainsKey(eventID))
            eventManager[eventID] += callback;
        else
        {
            eventManager.Add(eventID, null);
            eventManager[eventID] += callback;
        }

    }

    public void RemoveListener(EventID eventID, Action<Object> callback)
    {
        if (eventManager.ContainsKey(eventID)) eventManager[eventID] -= callback;
        else
        {
            Debug.LogError("Doesn't contain eventID");
        }
    }

    public void PostEvent(EventID eventID, Object param = null)
    {
        if(!eventManager.ContainsKey(eventID))
            Debug.LogError("Doesn't contain eventID");
        else
        {
            if(eventManager[eventID] == null) Debug.Log("Have event but do not have action");
            else
            {
                var callback = eventManager[eventID];
                callback(param);
            }
        }
    }
}
public static class EventDispatcherExtension{
    public static void AddListener(this MonoBehaviour listener, EventID eventID, Action<Object> callback)
    {
        EventDispatcher.Instance.AddListener(eventID, callback);
    }

    public static void RemoveListener(this MonoBehaviour listener, EventID eventID, Action<Object> callback)
    {
        EventDispatcher.Instance.RemoveListener(eventID, callback);
    }

    public static void PostEvent(this MonoBehaviour sender, EventID eventID, Object param = null)
    {
        EventDispatcher.Instance.PostEvent(eventID, param);
    }
}
