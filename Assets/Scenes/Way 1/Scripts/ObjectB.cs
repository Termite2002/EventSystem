using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Event.Way1;
using UnityEngine.UI;






public class ObjectB : MonoBehaviour
{
    public Text number;
    public Text word;
    public Image image;

    void Start()
    {
        EventManager.StartListening(GameEventKey.A_TO_B, OnEventFromA);
        EventManager.StartListening(GameEventKey.NO_Ag, OnEventNoAg);
    }
    private void OnDisable()
    {
        EventManager.StopListening(GameEventKey.A_TO_B, OnEventFromA);
        EventManager.StopListening(GameEventKey.NO_Ag, OnEventNoAg);
    }
    public void OnEventFromA(IDataEvent data)
    {
        if (data != null)
        {
            EventDataWay1 thisData = (EventDataWay1)data;

            number.text = thisData.a.ToString();

            word.text = thisData.b;

            image.sprite = thisData.sprite;
        }
    }
    public void OnEventNoAg(IDataEvent data = null)
    {
        Debug.Log("Event No Ag");
    }
}
