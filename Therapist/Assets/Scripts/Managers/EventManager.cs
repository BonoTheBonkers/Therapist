using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static string OnCursorClick = "OnCursorClick";

    public static string OnCorrectAnswer = "OnCorrectAnswer";
    public static string OnWrongAnswer = "OnWrongAnswer";
    public static string OnTargetTokenPlaceChanged = "OnTargetTokenPlaceChanged";

    public static string OnLanguageChanged = "OnLanguageChanged";
    public static string OnCurrentLevelChanged = "OnCurrentLevelChanged";
    public static string OnBoardChanged = "OnBoardChanged";
    public static string OnSequenceChanged = "OnSequenceChanged";
    public static string OnCurrentScreenChanged = "OnCurrentScreenChanged";
    public static string OnCurrentProgressLevelChanged = "OnCurrentProgressLevelChanged";
    public static string OnCurrentAttributeChanged = "OnCurrentAttributeChanged";
    public static string OnPlayersListChanged = "OnPlayersListChanged";
    public static string OnPlayerChanged = "OnPlayerChanged";
    public static string OnContraindicationsChanged = "OnContraindicationsChanged";
    public static string OnOptionScreenOpened = "OnOptionScreenOpened";

    public static string OnInitializeBoard = "OnInitializeBoard";

    public static string OnApplicationDataChanged = "OnApplicationDataChanged";
    public static string OnApplicationDataLoaded = "OnApplicationDataLoaded";


    private Dictionary<string, UnityEvent> eventDictionary;

    private static EventManager manager;

    public static EventManager instance
    {
        get
        {
            if (!manager)
            {
                manager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!manager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    manager.Init();
                }
            }

            return manager;
        }
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        if (manager == null) return;
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
