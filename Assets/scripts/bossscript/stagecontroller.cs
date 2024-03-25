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
    GameObject boss1;
    float cx=-240,cy=0,lx=735,ly=540;
    void Start()
    {
        enemy_drop=Resources.Load("enemy/prefab/enemy_drop") as GameObject;
        enemy_melee=Resources.Load("enemy/prefab/enemy_melee") as GameObject;
        enemy_snipe=Resources.Load("enemy/prefab/enemy_snipe") as GameObject;
        boss1=Resources.Load("enemy/prefab/boss_1") as GameObject;
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
        if(framed==1){
            if(timer==360){
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
            if(timer==720){
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
            if(timer==1440){
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
            if(timer==1800){
                GameObject e1=Instantiate(enemy_snipe);
            }
            if(timer==2400){
                GameObject e1=Instantiate(boss1);
            }
        }
    }
}
