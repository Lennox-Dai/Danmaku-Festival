using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class aya_210 : MonoBehaviour
{
    // Start is called before the first frame update
    float lti=0f;
    float frame=0.016f;
    float rdeg=0;
    public int timer=0;
    int framed=1;
    bool fire=false;
    GameObject bullet1=null;
    Sprite arrow;
    Sprite grain2,grain3;
    float cx=-240,cy=0;//,lx=735,ly=540;
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
        return (float)Math.Sqrt(pf(Math.Abs(x1-x2))+pf(Math.Abs(y1-y2)));
    }
    
    phase_shift ps;
    float t1,t2,t3,t4;
    void cphase(){
        t1=60;
        t2=t1+60;
        t3=t2+180;
        t4=t3+60;
    }
    void Start()
    {
        cphase();
        ps=GetComponent<phase_shift>();
        //transform.localPosition=new Vector3(0,100,0);
        bullet1=Resources.Load("enemy/prefab/bullet_aya_210") as GameObject;
        grain2=Resources.Load<Sprite>("enemy/grain2") as Sprite;
        grain3=Resources.Load<Sprite>("enemy/grain3") as Sprite;
    }
    bool csh=false;
    bool st=false;
    // Update is called once per frame
    
    /*
    <t1:nothing
    t1<t<t2:210
    t2<t<t3:snipe
    t3<t<t4:move
    t4<t:t=0
    */
    void Update()
    {
        Debug.Log(Time.time+" "+lti);
        if(Time.time-lti>frame){
            Debug.Log(timer);
            timer++;
            framed=1;
            lti=Time.time;
        }
        else{
            framed=0;
        }
        Debug.Log(Time.time+" kk "+lti);
        
        if(framed==1){
            if(timer<t1){

            }
            if(t1<=timer&&timer<t2){
                if(timer==t1){
                    rdeg=UnityEngine.Random.Range(0,22.5f);
                }
                if(timer%4==0){
                    int ti=16;
                    float bs=2f;
                    for (int i=0;i<=ti;i++){
                        GameObject bul=Instantiate(bullet1);
                        bullet_aya_210 b210=bul.GetComponent<bullet_aya_210>();
                        b210.init(transform.localPosition.x,transform.localPosition.y,
                        5,rdeg+i*360/ti,1,grain2);
                        basicbullet basb=bul.GetComponent<basicbullet>();
                        basb.chscale(bs,bs);
                    }
                    for (int i=0;i<=ti;i++){
                    
                        GameObject bul=Instantiate(bullet1);
                        bullet_aya_210 b210=bul.GetComponent<bullet_aya_210>();
                        b210.init(transform.localPosition.x,transform.localPosition.y,
                        5,rdeg+i*360/ti+11.25f,-1,grain3);
                        basicbullet basb=bul.GetComponent<basicbullet>();
                        basb.chscale(bs,bs);
                    }
                }
            }
            if(t2<=timer&&timer<t3){

            }
            if(t3<=timer&&timer<t4){
                if(timer==t3){
                    float cx=-240f,cy=0,lx=735f,ly=540f;
                    float pst=0.8f;
                    Vector2 tgt=new Vector2(UnityEngine.Random.Range(cx-lx*pst,cx+lx*pst),UnityEngine.Random.Range(cy-ly*pst,cy+ly*pst));
                    float deg=gdeg(gameObject,tgt.x,tgt.y);
                    float d=dis(gameObject,tgt.x,tgt.y);
                    float v1=d/(t4-t3);
                    basicbullet basb=GetComponent<basicbullet>();
                    basb.chdeg(deg);
                    basb.chv(v1);
                }
                
            }
            else if(timer>=t4){
                basicbullet basb=GetComponent<basicbullet>();
                basb.chv(0);
                timer=0;
            }
        }
    }
}
