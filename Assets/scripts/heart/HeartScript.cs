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
    public float birthtime;
    private bool cnt;
    void Start()
    {
        alive = true;
        HeartRender = GetComponent<SpriteRenderer>();
        HeartBeats = 0;
        HeartTime = -100f;
        t = true;
        cnt = false;
        //birthtime = Time.time - 8f;
    }

    void Update()
    {
        if (cnt){
            birthtime = Time.time;
            cnt = false;
        }
        if (Time.time - birthtime > 8f){
            if(Time.time - HeartTime > 0.1f){
                if(HeartBeats >= Heart.Length - 2){
                    HeartBeats = 0;
                    if (alive)HeartRender.sprite = Heart[HeartBeats];
                    HeartTime = Time.time;
                    cnt = true;
                }else{
                    // Debug.Log("HeartBeats" + transform.gameObject + HeartBeats);
                    SpriteRenderer sr=GetComponent<SpriteRenderer>();
                    HeartBeats += 1;
                    if (alive)sr.sprite = Heart[HeartBeats];
                    HeartTime = Time.time;
                }
            }
        }
    }

    public void TurnAlive(){
        alive = true;
        //HeartRender.sprite = Heart[0];
    }

    public void ChangeAlive(){
        HeartRender.sprite = Heart[0];
    }

    public void BirthTimeAdd(float a){
        birthtime += a;
    }

    public void TurnDead(){
        alive = false;
        HeartRender.sprite = Heart[Heart.Length - 1];
    }
}
