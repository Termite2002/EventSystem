using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Event.Way1;
using Event.Way2;


public struct EventDataWay1 : IDataEvent
{
    public int a;
    public string b;
    public Sprite sprite;

    public EventDataWay1(int a, string b, Sprite spr)
    {
        this.a = a;
        this.b = b;
        this.sprite = spr;
    }
}
public class ObjectA : MonoBehaviour
{
    [SerializeField] Sprite sprite;
    [SerializeField] int a = 10;
    [SerializeField] string b = "haha";


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.TriggerEvent(GameEventKey.A_TO_B, new EventDataWay1(a, b, sprite));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            EventManager.TriggerEvent(GameEventKey.NO_Ag);
        }
    }


}
