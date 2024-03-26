using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phase_shift : MonoBehaviour
{
    // Start is called before the first frame update
    MonoBehaviour[] phases=new MonoBehaviour[10];
    int phase=1;
    int maxphase=3;
    float cx=-240,cy=0,lx=735,ly=540;
    public bool invulnerable=false;
    GameObject enemy_melee;
    static private SHAKE sh = null;
    static public void getSHAKE(SHAKE g){
        sh = g;
    } 
    public void rest(){
        GameObject e1=Instantiate(enemy_melee);
        basicbullet bsb=e1.GetComponent<basicbullet>();
        bsb.chplace(cx-lx/2,cy+ly-1);
        datas self=e1.GetComponent<datas>();
        self.hp=100;
        
        e1=Instantiate(enemy_melee);
        bsb=e1.GetComponent<basicbullet>();
        bsb.chplace(cx+lx/2,cy+ly-1);
        self=e1.GetComponent<datas>();
        self.hp=100;
    }
    void Start()
    {
        enemy_melee=Resources.Load("enemy/prefab/enemy_melee") as GameObject;
        phases[1]=GetComponent<stars>();
        phases[2]=GetComponent<aya_210>();
        phases[3]=GetComponent<wave_part>();
        for(int i=1;i<=maxphase;i++){
            phases[i].enabled=false;
        }
        datas self=GetComponent<datas>();
        self.group=3;
        self.mhp=2500;
        self.hp=self.mhp;
        basicbullet bsb=GetComponent<basicbullet>();
        bsb.rbound=true;
        bsb.bound=false;
        bsb.chcolli(32,32);
        phases[1].enabled=true;
    }
    
    // Update is called once per frame
    void Update()
    {
        datas self=GetComponent<datas>();
        self.phase=phase;
        if(self.hp<0){
            self.hp=self.mhp;
            phases[phase].enabled=false;
            phase++;
            if(phase>maxphase){
                dest();
                return;
            }
            phases[phase].enabled=true;
        }
    }
    void dest(){
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D cld){
        if (sh != null){
            if(invulnerable){
                return;
            }
            datas self=GetComponent<datas>();
            healthbar hb=cld.gameObject.GetComponent<healthbar>();
            sh.updatehealth(cld.gameObject.name);
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
}