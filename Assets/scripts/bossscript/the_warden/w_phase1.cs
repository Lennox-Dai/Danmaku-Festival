using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w_phase1 : MonoBehaviour
{
    // Start is called before the first frame update
    float lti=0;
    float frame=0.016f;
    int timer=0;
    GameObject bullet1=null;
    GameObject hero=null;
    Sprite knifer,knifeg;
    float cx=-240,cy=0,lx=735,ly=540;
    float t1,t2,t3,t4,t5,t6,t7;
    void Start()
    {
        hero=GameObject.Find("Hero");
        bullet1=Resources.Load("enemy/prefab/bulletclass") as GameObject;
        knifer=Resources.Load<Sprite>("enemy/knifes/knife_1") as Sprite;
        knifeg=Resources.Load<Sprite>("enemy/knifes/knife_2") as Sprite;
        t1=30;
        t2=t1+90;
        t3=t2+20;
        t4=t3+90;
        t5=t4+20;
        t6=t5+150;
        t7=t6+90;
    }

    // Update is called once per frame
    //0-t1 moveto右上
    //t1-t2 蓄力（特效tbd）
    //t2-t3 moveto左上，射2way
    //t3-t4 蓄力
    //t4-t5 moveto右上，射3way
    //t5-t6 停一小段时间
    //t6-t7 回到中上
    //>t7 rax=1;
    void genpower(float ti){

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
                basb.moveto(cx-lx/2,cy+ly/2,t1-1);
            }
        }
        else if(timer<t2){
            if(timer==t1){
                genpower(t2-t1);
            }
            
        }
        else if(timer<t3){
            if(timer==t2){
                basb.moveto(cx+lx/2,cy,t3-t2);
            }
            float div=30f;
            int way=4;
            float ndeg=basb.gdeg2(gameObject,hero)-div*(way-1)/2f;
            for(int k=1;k<=way;k++){
                for(int i=1;i<=4;i++){
                    GameObject bul=Instantiate(bullet1);
                    basicbullet bulb=bul.GetComponent<basicbullet>();
                    bulb.chplace(transform.localPosition.x,transform.localPosition.y);
                    bulb.chdeg(ndeg);
                    bulb.chrot(ndeg);
                    bulb.chv(1+i*1f);
                    bulb.chimg(knifer);
                    bulb.chscale(2,2);
                }
                ndeg+=div;
            }
            
        }
        else if(timer<t4){
            if(timer==t3){
                genpower(t4-t3);
            }
        }
        else if(timer<t5){
            if(timer==t4){
                basb.moveto(cx-lx*0.5f,cy+ly/2,t5-t4);
            }
            int way=3;
            float div=30f;
            float ndeg=basb.gdeg2(gameObject,hero)-div*(way-1)/2f;
            for(int k=1;k<=4;k++){
                for(int i=1;i<=4;i++){
                    GameObject bul=Instantiate(bullet1);
                    basicbullet bulb=bul.GetComponent<basicbullet>();
                    bulb.chplace(transform.localPosition.x,transform.localPosition.y);
                    bulb.chdeg(ndeg);
                    bulb.chrot(ndeg);
                    bulb.chv(3+i*0.8f);
                    bulb.chimg(knifeg);
                    bulb.chscale(2,2);
                }
                ndeg+=div;
            }
        }
        else if(timer<t6){
            //nothing
        }
        else if(timer<t7){
            if(timer==t6){
                basb.moveto(cx,cy+ly/2,t7-t6);
            }
        }
        else{
            timer=0;
            self.rax=1;
        }
    }
}
