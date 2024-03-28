using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class w_phase5 : MonoBehaviour
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
    Sprite grain;
    float cx=-240,cy=0,lx=735,ly=540;
    float t1,t2,t3,t4,t5;
    void Start()
    {
        hero=GameObject.Find("Hero");
        bullet1=Resources.Load("enemy/prefab/bulletclass") as GameObject;
        grain=Resources.Load<Sprite>("enemy/grain3") as Sprite;
        t1=60;
        t2=t1+30;
        t3=t2+600;
        t4=t3+30;
        t5=t4+180;
    }

    // Update is called once per frame
    //无双风神！
    //<t1:moveto中心
    //t1-t2:moveto左上
    //t2-t3:不断左右来回moveto，发弹，越来越快，（可能有的）激光特效
    //t3-t4:moveto中心
    //t4-t5:nothing
    //>t5:rax
    int gap=50;
    int leftgap=0;
    int nowpos=0;
    void spgrain(){
        GameObject bul=Instantiate(bullet1);
        bul.AddComponent<p5_grain>();
        p5_grain bulb=bul.GetComponent<p5_grain>();
        bulb.csh(UnityEngine.Random.Range(-2f,2f),UnityEngine.Random.Range(0.1f,3f),-0.1f,-4f);
        float xx=gameObject.transform.localPosition.x,yy=gameObject.transform.localPosition.y;
        bulb.chp(xx+UnityEngine.Random.Range(-40f,40f),yy+UnityEngine.Random.Range(-40f,40f));
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
        if(timer<t1){
            if(timer==1){
                basb.moveto(cx,cy+ly/2,t1-1);
            }
            
            nowpos=0;
            gap=50;
        }
        else if(timer<t2){
            if(timer==t2){
                basb.moveto(cx-lx+1,cy+UnityEngine.Random.Range(ly*0.1f,ly*0.9f),t2-t1);
            }
            
        }
        else if(timer<t3){
            if(timer-t2>180){
                gap=10;
            }
            if(leftgap==0){
                leftgap=gap;
                if(nowpos==0){
                    basb.moveto(cx+lx-1,cy+UnityEngine.Random.Range(ly*0.1f,ly*0.9f),gap);
                    nowpos=1;
                }
                else{
                    basb.moveto(cx-lx+1,cy+UnityEngine.Random.Range(ly*0.1f,ly*0.9f),gap);
                    nowpos=0;
                }
            }
            else{
                leftgap--;
            }
            spgrain();
        }
        else if(timer<t4){
            basb.moveto(cx,cy+ly/2,t1-1);
        }
        else if(timer<t5){
            //nothing
        }
        else{
            timer=0;
            self.rax=1;
            gap=50;
        }
    }
}
