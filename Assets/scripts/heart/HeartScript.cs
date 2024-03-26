using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;

public class HeartScript : MonoBehaviour
{

    private bool alive;
    private bool t;
    public Sprite[] Heart; 
    private int HeartBeats;
    private SpriteRenderer HeartRender; 
    private float HeartTime;
    private float birthtime;
    private bool cnt;
    void Start()
    {
        alive = true;
        HeartRender = GetComponent<SpriteRenderer>();
        HeartBeats = 0;
        HeartTime = -100f;
        t = true;
        cnt = false;
    }

    void Update()
    {
        if (alive){
            if (cnt){
                birthtime = Time.time;
                cnt = false;
            }
            if (Time.time - birthtime > 8){
                if(Time.time - HeartTime > 1/6f){
                    if(HeartBeats == Heart.Length - 1){
                        HeartBeats = 0;
                        HeartRender.sprite = Heart[HeartBeats];
                        HeartTime = Time.time;
                        cnt = true;
                    }else{
                        Debug.Log("HeartBeats" + HeartBeats);
                        HeartRender.sprite = Heart[HeartBeats];
                        HeartBeats = HeartBeats + 1;
                        HeartTime = Time.time;
                    }
                }
            }
        }
    }

    public void TurnAlive(){
        alive = true;
        HeartRender.sprite = Heart[0];
    }

    public void BirthTimeAdd(float a){
        birthtime += a;
    }

    public void TurnDead(){
        alive = false;
        HeartRender.sprite = Heart[Heart.Length - 1];
    }

    // public IEnumerator Leap(){
    //     if (!alive){
    //         yield break;
    //     }
    //     t = true;
    //     while (t){
    //         if(Time.time - HeartTime > 1/6f){
    //             if(HeartBeats == Heart.Length - 1){
    //                 HeartBeats = 0;
    //                 HeartRender.sprite = Heart[HeartBeats];
    //                 HeartTime = Time.time;
    //                 t = false;
    //             }
    //             HeartRender.sprite = Heart[HeartBeats];
    //             HeartBeats = HeartBeats + 1;
    //             HeartTime = Time.time;
    //             // Debug.Log("cnt" + HeartBeats);
    //         }
    //     }
    //     // yield return null;
    // }
}
