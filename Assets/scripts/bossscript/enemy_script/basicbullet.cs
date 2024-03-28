using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public partial class basicbullet : MonoBehaviour
{
    // Start is called before the first frame update
    public bool bound=true;
    public bool rbound=false;
    public float movesti=0;
    public float moveti=0;
    float frame=0.0166f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scrcheck();
        //中心是-240,0
        //长1470，宽1080
        if(moveti!=0&&Time.time-movesti>moveti*frame){
            chv(0);
            moveti=0;
        }
    }
    void scrcheck(){

        if (bound){
            float cx=-240,cy=0,lx=735,ly=540;
            float sx=transform.localPosition.x;
            float sy=transform.localPosition.y;
            if(sx<cx-lx||sx>cx+lx||sy>cy+ly||sy<cy-ly){
                if(bound){
                    Destroy(gameObject);
                }
                if(rbound){
                    sx=Math.Min(cx+lx,sx);
                    sx=Math.Max(cx-lx,sx);
                    sy=Math.Min(cy+ly,sy);
                    sy=Math.Max(cy-ly,sy);
                }
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
        if(cld.gameObject.name=="Shield(Clone)"||cld.gameObject.name=="Hero"){
            if(self.group==0){
                Destroy(gameObject);
            }
        }
    }
    
    public void chplace(float x,float y){
        Vector3 vec=new Vector3(x,y,0);
        transform.localPosition=vec;
    }
    public void chplace_z(float z){
        Vector3 vec=transform.localPosition;
        vec.z=z;
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
    
    public float gdeg(GameObject x,float x2,float y2){
        float x1=x.transform.localPosition.x,y1=x.transform.localPosition.y;
        float ch=0;
        if(x1>x2){
            ch=180f;
        }
        return (float)Math.Atan((y2-y1)/(x2-x1))*180/3.14f+ch;
    }
    public float gdeg2(GameObject x,GameObject y){
        float x1=y.transform.localPosition.x,y1=y.transform.localPosition.y;
        return gdeg(x,x1,y1);
    }
    public float atan(float x,float y){
        float ch=0;
        if(x<0){
            ch=180f;
        }
        return (float)Math.Atan(y/x)*180/3.14f+ch;
    }
    public float moveto(float tox,float toy,float ti){
        datas self=GetComponent<datas>();
        float sx=transform.localPosition.x,sy=transform.localPosition.y;
        float vx=(tox-sx)/ti;
        float vy=(toy-sy)/ti;
        float vs=(float)Math.Sqrt(vx*vx+vy*vy);
        float ch=0;
        if(vx<0){
            ch=180f;
        }
        float deg=(float)Math.Atan(vy/vx)*180/3.14f+ch;
        chv(vs);
        chdeg(deg);
        movesti=Time.time;
        moveti=ti;
        //Debug.Log(sx+" "+sy+" "+tox+" "+toy+" "+deg);
        return deg;
        //返回deg，调用者以此自行修改rot
    }
    public float gdis(GameObject x,float x2,float y2){
        float x1=x.transform.localPosition.x,y1=x.transform.localPosition.y;
        float xx=x1-x2,yy=y1-y2;
        return (float)Math.Sqrt(xx*xx+yy*yy);
    }
    public void chalpha(float alpha){
        SpriteRenderer spr=GetComponent<SpriteRenderer>();
        Color col=spr.color;
        col.a=alpha;
        spr.color=col;
    }
}
