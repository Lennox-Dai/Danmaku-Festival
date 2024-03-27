using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningBlink : MonoBehaviour
{
    private float DeadTime;
    private bool increase;
    private float increase_speed;
    private bool blinking;
    void Start()
    {
        DeadTime = Time.time + 5f;
        increase = false;
        blinking = false;
        increase_speed = 0.05f;
        Renderer renderer = GetComponent<Renderer>();
        Color c = renderer.material.color;
        c.a = 0.6f;
        renderer.material.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        if (!blinking)StartCoroutine(Blink());
        blinking = true;
        if (Time.time >= DeadTime){
            Destroy(transform.gameObject);
        }
    }

    private IEnumerator Blink()
    {
        Debug.Log("shanle");
        Renderer renderer = GetComponent<Renderer>();
        Color c = renderer.material.color;
        float chg = increase_speed * Time.smoothDeltaTime;

        while (Time.time < DeadTime)  // 在剩余时间内循环
        {
            if (increase)
            {
                c.a += chg;
                if (c.a >= 0.6f)
                {
                    c.a = 0.6f; 
                    increase = false;
                }
            }
            else
            {
                c.a -= chg;
                if (c.a <= 0.001f)
                {
                    c.a = 0f;
                    increase = true;
                }
            }
            renderer.material.color = c;
            yield return null;  // 每0.1秒闪烁一次
        }
    }
}
