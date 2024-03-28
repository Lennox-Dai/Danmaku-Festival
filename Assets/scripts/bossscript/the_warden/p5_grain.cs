using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class p5_grain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sprite grain=Resources.Load<Sprite>("enemy/grain3") as Sprite;
        basicbullet basb=GetComponent<basicbullet>();
        basb.chimg(grain);
        basb.chscale(2,2);
    }

    // Update is called once per frame
    float lti=0;
    float frame=0.016f;
    int timer=0;
    float vx=0,vy=0,a=0;
    float minvy=0;
    public void csh(float x,float y,float z,float w){
        //vx,vy,a,minvy
        vx=x;
        vy=y;
        a=z;
        minvy=w;
    }
    public void chp(float x,float y){
        basicbullet basb=GetComponent<basicbullet>();
        basb.chplace(x,y);
    }
    void Update()
    {
        basicbullet basb=GetComponent<basicbullet>();
        datas self=GetComponent<datas>();
        if(Time.time-lti>frame){
            timer++;
            lti=Time.time;
        }
        else{
            return;
        }
        float d1=basb.atan(vx,vy);
        basb.chrot(d1);
        basb.chdeg(d1);
        basb.chv((float)Math.Sqrt(vy*vy+vx*vx));
        if(vy>minvy){
            vy+=a;
        }
    }
}
