using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class w_phase3 : MonoBehaviour
{
    // Start is called before the first frame update
    float lti=0;
    float frame=0.016f;
    int timer=0;
    int leftm=0;
    GameObject bullet1=null;
    GameObject laser1=null;
    GameObject hugeknife=null;
    GameObject hero=null;
    basicbullet swb=null;
    Sprite knifer,knifeg;
    float cx=-240,cy=0,lx=735,ly=540;
    float t1,t2,t3,t4,t5,t6,t7,t8;
    void Start()
    {
        hero=GameObject.Find("Hero");
        bullet1=Resources.Load("enemy/prefab/bulletclass") as GameObject;
        laser1=Resources.Load("enemy/prefab/laserclass") as GameObject;
        knifer=Resources.Load<Sprite>("enemy/knifes/knife_1_d") as Sprite;
        knifeg=Resources.Load<Sprite>("enemy/knifes/knife_2") as Sprite;
        t1=60;
        t2=t1+30;
        t3=t2+180;
        t4=t3+540;
        t5=t4+180;
    }

    // Update is called once per frame
    //0-t1 moveto中心
    //t1-t2 停一小会
    //t2-t3 开始有预警线，缓慢切
    //t3-t4 我tm切切切
    //t4-t5 停一小会
    //>t5 rax=1;
    int gap=50;
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
        if(timer<t1){
            basb.moveto(cx,cy,t1);
        }
        else if(timer<t2){
            //nothing
        }
        else if(timer<t3){
            if(timer%50==0){
                GameObject lsr=Instantiate(laser1);
            }
            
        }
        else if(timer<t4){
            if(timer%gap==0){
                GameObject lsr=Instantiate(laser1);
            }
            if(timer-t3<100){
                gap=40;
            }
            else if(timer-t3<180){
                gap=20;
            }
            else{
                gap=10;
            }
        }
        else if(timer<t5){
            //nothing
        }
        else{
            timer=0;
            self.rax=1;
        }
    }
}
