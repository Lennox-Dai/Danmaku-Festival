using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 此方法使用了固定时间（bunus time),可以考虑改成固定奖励个数
public class ShieldScript : MonoBehaviour
{
    static private HeroCrush h = null;
    private float DeadTime;
    private bool increase;
    private float increase_speed;
    static public void getHero(HeroCrush g){
        h = g;
    } 
    private bool blinking;
    public float lasting; 
    void Start()
    {
        DeadTime = Time.time + lasting;
        transform.position = h.transform.position;
        increase = false;
        blinking = false;
        increase_speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!blinking && ((Time.time + 2) >= DeadTime)){
            blinking = true;
            StartCoroutine(Blink());
        }
        transform.position = h.transform.position;
        if (Time.time >= DeadTime){
            Destroy(transform.gameObject);
        }
    }

    private IEnumerator Blink()
    {
        Renderer renderer = GetComponent<Renderer>();
        Color c = renderer.material.color;
        float chg = increase_speed * Time.smoothDeltaTime;

        while (Time.time < DeadTime)  // 在剩余时间内循环
        {
            if (increase)
            {
                c.a += chg;
                if (c.a >= 0.999f)
                {
                    c.a = 1f; 
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

