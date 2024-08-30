using Event.Way2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obj_B : MonoBehaviour
{
    public Text number;
    public Text word;
    public Image image;

    EventBinding<EventACallB> EventAToBBinding;
    EventBinding<EventACallB> EventNoAg;

    private void OnEnable()
    {
        EventAToBBinding = new EventBinding<EventACallB>(HandleEvent);
        EventBus<EventACallB>.Register(EventAToBBinding);

        EventNoAg = new EventBinding<EventACallB>(HandleNoAg);
        EventBus<EventACallB>.Register(EventNoAg);
    }
    private void OnDisable()
    {
        EventBus<EventACallB>.Deregister(EventAToBBinding);
        EventBus<EventACallB>.Deregister(EventNoAg);
    }
    void HandleEvent(EventACallB e)
    {
        if (EventAToBBinding != null)
        {
            number.text = e.num.ToString();

            word.text = e.word;

            image.sprite = e.sprite;
        }
    }
    void HandleNoAg()
    {
        Debug.Log("no ag");
    }
}
