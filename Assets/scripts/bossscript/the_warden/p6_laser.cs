using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p6_laser : MonoBehaviour
{
    // Start is called before the first frame update
    Sprite laser;
    float t1,t2,t3;
    float alpha=0;
    GameObject hero=null;
    float cx=-240,cy=0,lx=735,ly=540;
    float scale=40f;
    float mscale=40f;
    float ms=4f;
    float camx,camy;
    GameObject cam;
    void Start()
    {
        cam=GameObject.Find("Main Camera");
        camx=cam.transform.localPosition.x;
        camy=cam.transform.localPosition.y;
        hero=GameObject.Find("Hero");
        laser=Resources.Load<Sprite>("enemy/laser/laser_2") as Sprite;
        basicbullet basb=GetComponent<basicbullet>();
        basb.chimg(laser);
        basb.chcolli(0,0);
        basb.chalpha(alpha);
        basb.chplace(cx,cy);
        basb.chplace_z(1);
        basb.chscale(20,scale);
        basb.chdeg(-90);
        basb.chrot(-90);
        datas self=GetComponent<datas>();
        self.group=2;
        t1=120;
        t2=t1+360;
        t3=t2+60;
    }
    float lti=0;
    float frame=0.016f;
    int timer=0;
    
    // Update is called once per frame

    //0-t1:预警
    //t1-t2:alpha=1,不断闪烁
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
            
            alpha+=0.5f/t1;
        }
        else if(timer<t2){
            alpha=0.99f;
            float div=0.05f;
            basb.chcolli(160f,8f);
            float div2=10;
            if(timer%6>3){
                basb.chscale(20,scale*(1+div));
                float ran=UnityEngine.Random.Range(-div2,div2);
                cam.transform.localPosition=new Vector3(camx+ran,camy+ran,-10);
            }
            else{
                basb.chscale(20,scale*(1-div));
                float ran=UnityEngine.Random.Range(-div2,div2);
                cam.transform.localPosition=new Vector3(camx+ran,camy+ran,-10);
            }
        }
        else if(timer<t3){
            if(timer==t2){
                cam.transform.localPosition=new Vector3(camx,camy,-10);
            }
            scale-=mscale/(t3-t2);
            basb.chscale(20,scale);
        }
        else{
            
            Destroy(gameObject);
        }
    }
}
