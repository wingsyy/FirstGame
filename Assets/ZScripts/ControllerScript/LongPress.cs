using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LongPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //按下多长时间算长按
    private float timeLongPress = 0.2f;

    //是否按下
    private bool isPointerDown = false;

    //按下时刻
    private float timePointerDown = 0;

    //回调方法
    public UnityEvent MethodCallBack;

    private float timer=0;
    void Update()
    {
        float span = Time.time - timePointerDown;
        if (isPointerDown && span > timeLongPress && Time.time >= timer)
        {
            MethodCallBack.Invoke();
            timer = Time.time + 0.2f;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        timePointerDown = Time.time;

        MethodCallBack.Invoke();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
    }
}