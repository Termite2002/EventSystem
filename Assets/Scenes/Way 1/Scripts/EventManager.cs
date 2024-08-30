using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Event.Way1
{
    public interface IDataEvent { }

    public class EventManager : MonoBehaviour
    {
        private Dictionary<GameEventKey, Action<IDataEvent>> eventDictionary;

        private static EventManager eventManager;

        public static EventManager instance
        {
            get
            {
                // if no instance is set, search for one in the scene
                if (!eventManager)
                {
                    eventManager = FindFirstObjectByType(typeof(EventManager)) as EventManager;

                    if (!eventManager)
                    {
                        // Still didn't find one, throw an error.
                        Debug.LogError("There needs to be one active EventManager script on a GameObject in your scene.");
                    }
                    else
                    {
                        // initialize the event dictionary for the newly found instance And flag it
                        // so it is not destroyed on scene loading
                        eventManager.Init();
                        DontDestroyOnLoad(eventManager);
                    }
                }
                return eventManager;
            }
        }

        /// <summary> Initializes the event dictionary. </summary>
        private void Init()
        {
            if (eventDictionary == null)
            {
                eventDictionary = new Dictionary<GameEventKey, Action<IDataEvent>>();
            }
        }

        /// <summary> Registers a function to the event listener. </summary>
        /// <param name="eventID">  The event we are listening for. </param>
        /// <param name="listener"> The function that is subscribing. </param>
        public static void StartListening(GameEventKey eventID, Action<IDataEvent> listener)
        {
            if (instance == null) return;

            Action<IDataEvent> thisEvent;

            if (instance.eventDictionary.TryGetValue(eventID, out thisEvent))
            {
                thisEvent += listener;
                instance.eventDictionary[eventID] = thisEvent;
            }
            else
            {
                thisEvent += listener;
                instance.eventDictionary.Add(eventID, thisEvent);
            }
        }

        /// <summary> Unregisters a function from the event listener. </summary>
        /// <param name="eventID">  The event we were looking for. </param>
        /// <param name="listener"> The function that was listening. </param>
        public static void StopListening(GameEventKey eventID, Action<IDataEvent> listener)
        {
            if (instance == null) return;
            if (instance.eventDictionary.TryGetValue(eventID, out Action<IDataEvent> thisEvent))
            {
                thisEvent -= listener;
                instance.eventDictionary[eventID] = thisEvent;
            }
        }

        /// <summary> Triggers an event, activating all the functions registered to the event. </summary>
        /// <param name="eventID">   The event to trigger. </param>
        /// <param name="eventData"> The data carried by the event. </param>
        public static void TriggerEvent(GameEventKey eventID, IDataEvent eventData = null)
        {
            if (instance.eventDictionary.TryGetValue(eventID, out Action<IDataEvent> thisEvent))
            {
                thisEvent?.Invoke(eventData);
            }
        }
    }
}