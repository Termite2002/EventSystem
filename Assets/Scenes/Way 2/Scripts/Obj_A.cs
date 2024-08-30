using Event.Way2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public struct EventACallB : IEvent
{
    public int num;
    public string word;
    public Sprite sprite;
}

public class Obj_A : MonoBehaviour
{
    [SerializeField] Sprite sprite;
    [SerializeField] int a = 10;
    [SerializeField] string b = "nguyen";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventBus<EventACallB>.Raise(new EventACallB { num = a, word = b, sprite = sprite });
        }
    }
}
