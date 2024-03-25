using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class enemy_drop : MonoBehaviour
{
    // Start is called before the first frame update
    float frame=0.0166f;
    int framed=0;
    float lastti=0;
    int timer=0;
    //float cx=-240,cy=0,lx=735,ly=540;
    public float fx=0;
    //GameObject h=null;
    GameObject bullet1=null;
    Sprite ball_huan;
    Sprite arrow;
    void Start()
    {
        bullet1=Resources.Load("enemy/prefab/bulletclass") as GameObject;
        ball_huan=Resources.Load<Sprite>("enemy/ball_mid_2") as Sprite;
        arrow=Resources.Load<Sprite>("enemy/grain1") as Sprite;
        datas self=GetComponent<datas>();
        self.hp=600f;
        self.group=2;
        basicbullet bsb=GetComponent<basicbullet>();
        bsb.chv(2);
        bsb.chcolli(16,16);
    }
    float gdeg(GameObject x,GameObject y){
        float x1=x.transform.localPosition.x,y1=x.transform.localPosition.y;
        float x2=y.transform.localPosition.x,y2=y.transform.localPosition.y;
        float ch=0;
        if(x1>x2){
            ch=180f;
        }
        return (float)Math.Atan((y2-y1)/(x2-x1))*180/3.14f+ch;
    }
    // Update is called once per frame
    int fst=0;
    void Update()
    {
        if(fst==0){
            fst=1;
            
        }
        if(Time.time-lastti>frame){
            timer++;
            framed=1;
            lastti=Time.time;
        }
        else{
            framed=0;
        }
        if(framed==1){
            datas self=GetComponent<datas>();
            if(self.hp<=0){
                Destroy(gameObject);
            }
            if(timer%24==0){
                for(int i=1;i<=12;i++){
                    GameObject bul=Instantiate(bullet1);
                    basicbullet basb=bul.GetComponent<basicbullet>();
                    basb.chplace(transform.localPosition.x,transform.localPosition.y);
                    float sdeg=-90;
                    basb.chdeg(sdeg);
                    basb.chrot(sdeg);
                    basb.chv(3*self.rbx);
                    basb.chimg(arrow);
                    basb.chscale(2,2);
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D cld){
        
        //1:player 2:playerbullet 3:enemy 4:enemybullet
        datas other=cld.gameObject.GetComponent<datas>();
        datas self=GetComponent<datas>();
        
        
        if(other!=null){
            //if(other.group==)
        }
        //因为我这边暂时没有碰撞，所以不需要以上
        
        if(cld.gameObject.name=="bomb(Clone)"){
            BombScript bscr=cld.gameObject.GetComponent<BombScript>();
            self.hp-=bscr.damage;
        }
        if(cld.gameObject.name=="HeroBullet(Clone)"){
            BulletScript bscr=cld.gameObject.GetComponent<BulletScript>();
            self.hp-=bscr.damage;
        }
        if(cld.gameObject.name=="NormalBullet(Clone)"){
            NormalBullet bscr=cld.gameObject.GetComponent<NormalBullet>();
            self.hp-=bscr.damage;
        }
    }
}
