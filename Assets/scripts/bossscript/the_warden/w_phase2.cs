using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class w_phase2 : MonoBehaviour
{
    // Start is called before the first frame update
    float lti=0;
    float frame=0.016f;
    int timer=0;
    int leftm=0;
    GameObject bullet1=null;
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
        knifer=Resources.Load<Sprite>("enemy/knifes/knife_1_d") as Sprite;
        knifeg=Resources.Load<Sprite>("enemy/knifes/knife_2") as Sprite;
        t1=30;
        t2=t1+90;
        t3=t2+60;
        t4=t3+30;
        t5=t4+10;
        t6=t5+60;
        t7=t6+240;
        t8=t7+60;
    }

    // Update is called once per frame
    //0-t1 moveto中心，生成刀
    //t1-t2 0.6时间用于moveto player
    //t2-t3 melee,转圈时间单独在函数中
    //t3-t4 停一小会，leftm--
    //t4-t5 若leftm>0，timer=t1
    //t5-t6 moveto player
    //t6-t7 刀转一圈，发射一圈弹幕！
    //t7-t8 停一小会
    //>t8 rax=1;
    void genpower(float ti){

    }
    float udeg=0,ddeg=0;
    float nowdeg=30;
    float kdeg=0;
    float ktimer=0;
    bool unlimited=false;
    void kart(){
        if(hugeknife==null){
            return;
        }
        basicbullet basb=hugeknife.GetComponent<basicbullet>();
        basb.bound=false;
        float x=transform.localPosition.x,y=transform.localPosition.y;
        basb.chplace(x,y);
        basb.chrot(nowdeg+kdeg);
    }
    void slash(){
        if(kdeg<360||unlimited){
            kdeg+=360f/12f;
        }
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
        kart();
        slash();
        if(timer<t1){
            if(timer==1){
                basb.moveto(cx,cy,t1-1);
                GameObject bul=Instantiate(bullet1);
                
                hugeknife=bul;
                
                swb=hugeknife.GetComponent<basicbullet>();
                swb.chimg(knifer);
                swb.chcolli(60,10);
                datas swd=hugeknife.GetComponent<datas>();
                swd.group=2;
                leftm=4;
            }
            swb.chscale(10,10);
        }
        else if(timer<t2){
            if(timer==t1){
                basb.moveto(hero.transform.localPosition.x,hero.transform.localPosition.y,(t2-t1)*0.8f);
                nowdeg=basb.gdeg2(gameObject,hero);
            }
            
        }
        else if(timer<t3){
            if(timer==t2){
                kdeg=0;
            }
            if(timer-t2>=12||timer%10!=0){
                return;
            }
            float div=15f;
            int way=10;
            float ndeg=basb.gdeg2(gameObject,hero)-div*(way-1)/2f;
            for(int k=1;k<=way;k++){
                for(int i=1;i<=1;i++){
                    GameObject bul=Instantiate(bullet1);
                    basicbullet bulb=bul.GetComponent<basicbullet>();
                    bulb.chplace(transform.localPosition.x,transform.localPosition.y);
                    bulb.chdeg(ndeg);
                    bulb.chrot(ndeg);
                    bulb.chv(5);
                    bulb.chimg(knifeg);
                    bulb.chscale(2,2);
                }
                ndeg+=div;
            }
            
        }
        else if(timer<t4){
            if(timer==t3){
                leftm--;
            }
        }
        else if(timer<t5){
            if(leftm>0){
                timer=(int)Math.Floor(t1)-1;
            }
        }
        else if(timer<t6){
            if(timer==t5){
                basb.moveto(cx,cy,t6-t5);
            }
        }
        else if(timer<t7){
            unlimited=true;
            int gap=12;
            if(timer>t6+(t7-t6)/2){
                gap=6;
            }
            if(timer%gap!=0){
                return;
            }
            
            float div=30f;
            int way=12;
            float ndeg=UnityEngine.Random.Range(0,360);
            for(int k=1;k<=way;k++){
                for(int i=1;i<=1;i++){
                    GameObject bul=Instantiate(bullet1);
                    basicbullet bulb=bul.GetComponent<basicbullet>();
                    bulb.chplace(transform.localPosition.x,transform.localPosition.y);
                    bulb.chdeg(ndeg);
                    bulb.chrot(ndeg);
                    bulb.chv(5);
                    bulb.chimg(knifeg);
                    bulb.chscale(2,2);
                }
                ndeg+=div;
            }
        }
        else if(timer<t8){
            unlimited=false;
        }
        else{
            timer=0;
            self.rax=1;
            Destroy(hugeknife);
        }
    }
}
