using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class enemy_melee : MonoBehaviour
{
    // Start is called before the first frame update
    float frame=0.0166f;
    int framed=0;
    float lastti=0;
    int timer=0;
    //float cx=-240,cy=0,lx=735,ly=540;
    GameObject h=null;
    GameObject bullet1=null;
    Sprite ball_huan;
    Sprite arrow;
    void Start()
    {
        bullet1=Resources.Load("enemy/prefab/bullet_melee") as GameObject;
        ball_huan=Resources.Load<Sprite>("enemy/ball_mid_1") as Sprite;
        datas self=GetComponent<datas>();
        self.hp=1000f;
        self.rbx=0;
        h=GameObject.Find("Hero");
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
        if(framed==1){
            datas self=GetComponent<datas>();
            self.rbx+=1;
            if(self.hp<=0){
                Destroy(gameObject);
            }
            if(timer==1){
                for(int i=1;i<=6;i++){
                    GameObject bul=Instantiate(bullet1);
                    basicbullet basb=bul.GetComponent<basicbullet>();
                    melee_ball mb=bul.GetComponent<melee_ball>();
                    mb.setparent(gameObject,i);
                    basb.chimg(ball_huan);

                }
            }
            if(timer%180==0){
                basicbullet basb=GetComponent<basicbullet>();
                basb.chv(0);
            }
            if(timer%180==60){
                basicbullet basb=GetComponent<basicbullet>();
                basb.chv(4);
                float sdeg=gdeg(gameObject,h);
                basb.chdeg(sdeg);
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
    }
}
