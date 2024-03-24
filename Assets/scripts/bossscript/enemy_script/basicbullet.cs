using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public partial class basicbullet : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject mcam;
    void Start()
    {
        mcam=GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        scrcheck();
        //中心是-240,0
        //长1470，宽1080
    }
    void scrcheck(){
        if (mcam!=null){
            float cx=-240,cy=0,lx=735,ly=540;
            float sx=transform.localPosition.x;
            float sy=transform.localPosition.y;
            if(sx<cx-lx||sx>cx+lx||sy>cy+ly||sy<cy-ly){
                Destroy(gameObject);
            }
            return;
            /*
            Camera cm=mcam.GetComponent<Camera>();
            
            float os = cm.orthographicSize;
            float lx=os* cm.aspect;
            float ly=os;
            float xx=cm.transform.localPosition.x;
            float yy=cm.transform.localPosition.y;
            float sx=transform.localPosition.x;
            float sy=transform.localPosition.y;
            Debug.Log(lx+" "+ly+" "+sx+" "+sy);
            if(sx<xx-lx||sx>xx+lx||sy<yy-ly||sy>yy+ly){
                Debug.Log(sx+" "+sy);
                Debug.Log((xx-lx)+" "+(yy-ly));
                Destroy(gameObject);
            }*/
        }
    }
    void OnTriggerEnter2D(Collider2D cld){
        //1:player 2:playerbullet 3:enemy 4:enemybullet
        datas other=cld.gameObject.GetComponent<datas>();
        datas self=GetComponent<datas>();
        if(other!=null){
            //if(other.group==)
        }
        if(cld.gameObject.name=="Shield(Clone)"){
            Destroy(gameObject);
        }
    }
    
    public void chplace(float x,float y){
        Vector3 vec=new Vector3(x,y,0);
        transform.localPosition=vec;
    }
    
    public void chv(float x){
        datas self=GetComponent<datas>();
        self.v=x;
    }
    public void chrotv(float x){
        datas self=GetComponent<datas>();
        self.rotv=x;
    }
    public void chdegv(float x){
        datas self=GetComponent<datas>();
        self.degv=x;
    }
    public void chdeg(float x){
        datas self=GetComponent<datas>();
        self.deg=x;
    }
    public void chrot(float x){
        datas self=GetComponent<datas>();
        self.rot=x;
    }
    public void chdra(float x){
        datas self=GetComponent<datas>();
        self.dra=x;
    }
    public void chimg(Sprite x){
        SpriteRenderer spr=GetComponent<SpriteRenderer>();
        spr.sprite=x;
    }
    public void chscale(float x,float y){
        transform.localScale=new Vector2(x,y);
    }
    public void chscv(float x,float y,float z,float w){
        datas self=GetComponent<datas>();
        self.scvx=x;
        self.scvy=y;
        self.scmvx=z;
        self.scmvy=w;
    }
    public void chcolli(float x,float y){
        datas self=GetComponent<datas>();
        self.a=x;
        self.b=y;
    }
}
