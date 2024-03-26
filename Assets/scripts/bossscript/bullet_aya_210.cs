using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_aya_210 : MonoBehaviour
{
    int type=0;
    int bj=0;
    int bj2=0;
    float lti=0;
    basicbullet basb;
    datas ds;
    // Start is called before the first frame update
    void Start()
    {
        lti=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time-lti>2&&bj==0){
            bj=1;
            basb=GetComponent<basicbullet>();
            
            basb.chdegv(0);
            basb.chrotv(0);
            basb.chdra(0);
            basb.chv(3);
        }
        if(Time.time-lti>2&&bj2==0){
            bj2=1;
            basb=GetComponent<basicbullet>();
            float ddeg=Random.Range(-1,1);
            basb.chrot(ds.rot+ddeg);
            basb.chdeg(ds.rot+ddeg);
            
        }
    }
    public void init(float x,float y,float v,float d,int ty,Sprite img){
        basb=GetComponent<basicbullet>();
        ds=GetComponent<datas>();
        // Debug.Log(basb==null);
        basb.chplace(x,y);
        basb.chdeg(d);
        basb.chrot(d);
        basb.chv(v);
        type=ty;
        basb.chdegv(1*ty);
        basb.chrotv(1*ty);
        basb.chdra(0.1f*ty);
        basb.chimg(img);
    }
}
