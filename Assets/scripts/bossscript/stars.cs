using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class stars : MonoBehaviour
{
    // Start is called before the first frame update
    float lastti=0f;
    float frame=0.016f;
    //float degv=0;

    int timer=0;
    int framed=1;
    GameObject bullet1=null;
    Sprite[] star=new Sprite[10];

    float cx=-240f,cy=0,lx=735f,ly=540f;
    float t1;
    float t2;
    float t3;
    float t4;
    void Start()
    {
        t1=60f;
        t2=t1+180f;
        t3=t2+60f;
        t4=t3+240f;
        bullet1=Resources.Load("enemy/prefab/bulletclass") as GameObject;
        for(int i=1;i<=8;i++){
            star[i]=Resources.Load<Sprite>("enemy/stars/star_"+i) as Sprite;
        }
        basicbullet basb=GetComponent<basicbullet>();
        basb.chplace(cx,cy+ly-1);
        basb.chv(4);
        basb.chdeg(-90);
        
    }
    float gdeg(GameObject x,float x2,float y2){
        float x1=x.transform.localPosition.x,y1=x.transform.localPosition.y;
        float ch=0;
        if(x1>x2){
            ch=180f;
        }
        return (float)Math.Atan((y2-y1)/(x2-x1))*180/3.14f+ch;
    }
    float pf(float x){
        return x*x;
    }
    float dis(GameObject x,float x2,float y2){
        float x1=x.transform.localPosition.x,y1=x.transform.localPosition.y;
        return (float)Math.Sqrt(pf(x1-x2)+pf(y1-y2));
    }
    // Update is called once per frame
    /*t<t1:nothing
    t1<t<t2:shoot!
    t2<t<t3:move to random
    t3<t<t4:snipe,rest()
    t4<t:t=0
    */
 
    bool ched=false;
    void Update()
    {
        if(Time.time-lastti>frame){
            timer++;
            framed=1;
            lastti=Time.time;
        }
        else{
            framed=0;
        }
        if(framed==0){
            return;
        }
        float t1=60;
        if(timer<t1){

        }
        else if(t1<=timer&&timer<t2){
            if(timer==t1){
                basicbullet basb=GetComponent<basicbullet>();
                basb.chv(0);
            }
            if(timer%15==0){
            
                int ti=12;
                int deg=UnityEngine.Random.Range(0,360);
                for (int i=0;i<=ti;i++){
                    GameObject bul=Instantiate(bullet1);
                    basicbullet basb=bul.GetComponent<basicbullet>();
                    basb.chplace(transform.localPosition.x,transform.localPosition.y);
                    basb.chdeg(deg+i*360/ti);
                    basb.chrotv(3f);
                    basb.chv(3f);
                    basb.chimg(star[UnityEngine.Random.Range(1,8)]);
                    basb.chscale(2,2);
                }
            
            }
        }
        else if(t2<=timer&&timer<t3){
            if(timer==t2){
                float pst=0.8f;
                Vector2 tgt=new Vector2(UnityEngine.Random.Range(cx-lx*pst,cx+lx*pst),UnityEngine.Random.Range(cy-ly*pst,cy+ly*pst));
                float deg=gdeg(gameObject,tgt.x,tgt.y);
                float d=dis(gameObject,tgt.x,tgt.y);
                float v=d/(t3-t2);
                basicbullet basb=GetComponent<basicbullet>();
                basb.chdeg(deg);
                basb.chv(v);
            }
            
        }
        else if(t3<=timer&&timer<t4){
            if(timer==t3){
                phase_shift sc=GetComponent<phase_shift>();
                sc.rest();
                basicbullet basb=GetComponent<basicbullet>();
                basb.chv(0);
            }
            
        }
        else{
            timer=0;
        }
    }
}
