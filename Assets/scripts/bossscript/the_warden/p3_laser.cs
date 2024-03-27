using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p3_laser : MonoBehaviour
{
    // Start is called before the first frame update
    Sprite laser;
    float t1,t2,t3;
    float alpha=0.1f;
    GameObject hero=null;
    float cx=-240,cy=0,lx=735,ly=540;
    float scale=4f;
    float ms=4f;
    void Start()
    {
        hero=GameObject.Find("Hero");
        laser=Resources.Load<Sprite>("enemy/laser/laser_1") as Sprite;
        basicbullet basb=GetComponent<basicbullet>();
        basb.chimg(laser);
        basb.chcolli(0,0);
        basb.chalpha(alpha);
        basb.chplace(Random.Range(cx-lx,cx+lx),Random.Range(cy-ly,cy+ly));
        basb.chscale(20,scale);
        float deg=basb.gdeg2(gameObject,hero);
        float div=Random.Range(-15,15);
        basb.chdeg(deg+div);
        basb.chrot(deg+div);
        datas self=GetComponent<datas>();
        self.group=2;
        t1=40;
        t2=t1+20;
        t3=t2+30;
    }
    float lti=0;
    float frame=0.016f;
    int timer=0;
    
    // Update is called once per frame

    //0-t1:预警
    //t1-t2:alpha=1,稍微变粗一点点，停留一小会（很小），有判定
    //t2-t3:变细直到消失
    
    void Update()
    {
        basicbullet basb=GetComponent<basicbullet>();
        if(Time.time-lti>frame){
            timer++;
            lti=Time.time;
        }
        else{
            return;
        }
        basb.chalpha(alpha);
        if(timer<t1){
            alpha+=0.02f;
        }
        else if(timer<t2){
            alpha=0.99f;
            float div=0.15f;
            basb.chcolli(160,8);
            if(timer%6>3){
                basb.chscale(20,scale*(1+div));
            }
            else{
                basb.chscale(20,scale*(1-div));
            }
        }
        else if(timer<t3){
            scale-=ms/(t3-t2);
            basb.chscale(20,scale);
        }
        else{
            Destroy(gameObject);
        }
    }
}
