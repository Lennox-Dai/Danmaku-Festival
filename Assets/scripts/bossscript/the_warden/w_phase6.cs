using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class w_phase6 : MonoBehaviour
{
    // Start is called before the first frame update
    float lti=0;
    float frame=0.016f;
    int timer=0;
    int leftm=0;
    GameObject bullet1=null;
    GameObject laser1=null;
    GameObject hero=null;
    Sprite grain,ice;
    float cx=-240,cy=0,lx=735,ly=540;
    float t1,t2,t3,t4,t5,t6;
    void Start()
    {
        hero=GameObject.Find("Hero");
        bullet1=Resources.Load("enemy/prefab/bulletclass") as GameObject;
        grain=Resources.Load<Sprite>("enemy/grain3") as Sprite;
        ice=Resources.Load<Sprite>("enemy/ice_1") as Sprite;
        t1=60;
        t2=t1+30;
        t3=t2+120;
        t4=t3+360;
        t5=t4+180;
        t6=t5+180;
    }

    // Update is called once per frame
    //激光炮！warden啊，你看到了吗!
    //<t1:moveto中心
    //t1-t2:moveto中上
    //t2-t3:蓄力预警线
    //t3-t4:魔炮，爽！同时底下发弹
    //t4-t5:魔炮缓慢变细，不发弹
    //t5-t6:nothing
    //>t6:rax
    int gap=50;
    int leftgap=0;
    int nowpos=0;
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
            if(timer==1){
                basb.moveto(cx,cy+ly/2,t1-1);
            }
            nowpos=0;
            gap=50;
        }
        else if(timer<t2){
            if(timer==t1){
                basb.moveto(cx,cy+UnityEngine.Random.Range(ly*0.1f,ly*0.9f),t2-t1);
            }
            
        }
        else if(timer<t3){
            if(timer==t2){
                GameObject bul=Instantiate(bullet1);
                bul.AddComponent<p6_laser>();
            }
        }
        else if(timer<t4){
            if(timer%2==0){
                GameObject ice_bullet=Instantiate(bullet1);
                basicbullet bul=ice_bullet.GetComponent<basicbullet>();
                bul.chplace(UnityEngine.Random.Range(cx-lx+1,cx+lx-1),cy-ly+1);
                float deg1=UnityEngine.Random.Range(30,150);
                bul.chdeg(deg1);
                bul.chrot(deg1);
                bul.chv(UnityEngine.Random.Range(2f,4f));
                bul.chimg(ice);
                bul.chscale(4,4);
            }
            
            //shoot some bullet
        }
        else if(timer<t5){
            //nothing
        }
        else if(timer<t6){
            //nothing
        }
        else{
            timer=0;
            self.rax=1;
        }
    }
}
