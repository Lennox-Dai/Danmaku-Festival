using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stagecontroller : MonoBehaviour
{
    // Start is called before the first frame update
    int timer=0;
    float frame=0.0166f;
    float lastti=0;
    int framed=0;
    GameObject enemy_drop;
    GameObject enemy_melee;
    GameObject enemy_snipe;
    GameObject boss1,boss2;
    GameObject b1;
    bool finished=false;
    float cx=-240,cy=0,lx=735,ly=540;
    void Start()
    {
        enemy_drop=Resources.Load("enemy/prefab/enemy_drop") as GameObject;
        enemy_melee=Resources.Load("enemy/prefab/enemy_melee") as GameObject;
        enemy_snipe=Resources.Load("enemy/prefab/enemy_snipe") as GameObject;
        boss1=Resources.Load("enemy/prefab/boss_1") as GameObject;
        boss2=Resources.Load("enemy/prefab/boss_2_warden") as GameObject;
        //GameObject e1=Instantiate(boss1);
    }
    
    // Update is called once per frame
    //float t1=4f;
    void Update()
    {
        //return;
        if(Time.time-lastti>frame){
            timer++;
            framed=1;
            lastti=Time.time;
        }
        else{
            framed=0;
        }
        float t1,t2,t3,t4,t5,t6,t7;
        //<t1:nothing
        //t1-t2:t1=drop2
        //t2-t3:t2=melee4
        //t3-t4:t3=drop4
        //t4-t5:t4=snipe
        //t5+:t5=boss!
        t1=360;
        t2=t1+360;
        t3=t2+720;
        t4=t3+360;
        t5=t4+1300;
        if(framed==1){
            if(timer==t1){
                GameObject e1=Instantiate(enemy_drop);
                datas self=e1.GetComponent<datas>();
                basicbullet bsb=e1.GetComponent<basicbullet>();
                bsb.chplace(cx-lx+1,cy+ly/2);
                bsb.chv(2f);
                self.rbx=1;
                GameObject e2=Instantiate(enemy_drop);
                self=e2.GetComponent<datas>();
                bsb=e2.GetComponent<basicbullet>();
                bsb.chplace(cx+lx-1,cy-ly/2);
                bsb.chv(2f);
                bsb.chdeg(180);
                self.rbx=-1;
            }
            if(timer==t2){
                GameObject e1=Instantiate(enemy_melee);
                basicbullet bsb=e1.GetComponent<basicbullet>();
                bsb.chplace(cx-lx/2,cy+ly-1);
                e1=Instantiate(enemy_melee);
                bsb=e1.GetComponent<basicbullet>();
                bsb.chplace(cx+lx/2,cy+ly-1);
                e1=Instantiate(enemy_melee);
                bsb=e1.GetComponent<basicbullet>();
                bsb.chplace(cx+lx/2,cy-ly+1);
                e1=Instantiate(enemy_melee);
                bsb=e1.GetComponent<basicbullet>();
                bsb.chplace(cx-lx/2,cy-ly+1);
            }
            if(timer==t3){
                GameObject e2=Instantiate(enemy_melee);
                basicbullet bsb2=e2.GetComponent<basicbullet>();
                bsb2.chplace(cx,cy+ly-1);
                e2=Instantiate(enemy_melee);
                bsb2=e2.GetComponent<basicbullet>();
                bsb2.chplace(cx,cy-ly+1);

                GameObject e1=Instantiate(enemy_drop);
                datas self=e1.GetComponent<datas>();
                basicbullet bsb=e1.GetComponent<basicbullet>();
                bsb.chplace(cx-lx+1,cy+ly/2);
                bsb.chv(2f);
                self.rbx=1;
                e1=Instantiate(enemy_drop);
                self=e1.GetComponent<datas>();
                bsb=e1.GetComponent<basicbullet>();
                bsb.chplace(cx-lx+1,cy-ly/2);
                bsb.chv(2f);
                self.rbx=-1;
                e1=Instantiate(enemy_drop);
                self=e1.GetComponent<datas>();
                bsb=e1.GetComponent<basicbullet>();
                bsb.chplace(cx+lx-1,cy+ly/2);
                bsb.chv(2f);
                bsb.chdeg(180);
                self.rbx=1;
                e1=Instantiate(enemy_drop);
                self=e1.GetComponent<datas>();
                bsb=e1.GetComponent<basicbullet>();
                bsb.chplace(cx+lx-1,cy-ly/2);
                bsb.chv(2f);
                bsb.chdeg(180);
                self.rbx=-1;
            }
            if(timer==t4){
                GameObject es=Instantiate(enemy_snipe);

                GameObject e1=Instantiate(enemy_drop);
                datas self=e1.GetComponent<datas>();
                basicbullet bsb=e1.GetComponent<basicbullet>();
                bsb.chplace(cx-lx+1,cy+ly-1);
                bsb.chv(2f);
                bsb.chdeg(-45);
                self.rbx=1;
                e1=Instantiate(enemy_drop);
                self=e1.GetComponent<datas>();
                bsb=e1.GetComponent<basicbullet>();
                bsb.chplace(cx+lx-1,cy+ly-1);
                bsb.chv(2f);
                bsb.chdeg(-135);
                self.rbx=1;
            }
            if(timer==t5){
                GameObject e1=Instantiate(boss1);
                b1=e1;
                datas datas = e1.GetComponent<datas>();
                GameObject Backbar = Instantiate(Resources.Load("prefabs/backbar") as GameObject);
                GameObject Frontbar = Instantiate(Resources.Load("prefabs/frontbar") as GameObject);
                healthbar.getbossdata(datas);
            }
        }
    }
}
