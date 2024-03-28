using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class boss2_phase_shift : MonoBehaviour
{
    // Start is called before the first frame update
    MonoBehaviour[] phases=new MonoBehaviour[10];
    public int phase=4;
    int maxphase=6;
    float cx=-240,cy=0,lx=735,ly=540;
    public bool invulnerable=false;
    static private SHAKE sh = null;
    static public void getSHAKE(SHAKE g){
        sh = g;
    } 
    void Start()
    {
        
        //enemy_melee=Resources.Load("enemy/prefab/enemy_melee") as GameObject;
        phases[0]=GetComponent<w_phase1>();
        phases[1]=GetComponent<w_phase2>();
        phases[2]=GetComponent<w_phase3>();
        phases[3]=GetComponent<LaserController>();
        phases[4]=GetComponent<w_phase5>();
        phases[5]=GetComponent<w_phase6>();
        for(int i=0;i<maxphase;i++){
            if(phases[i]!=null){
                phases[i].enabled=false;
            }
        }
        datas self=GetComponent<datas>();
        self.group=3;
        self.mhp=45000;
        self.hp=self.mhp;
        self.phase=1;
        basicbullet bsb=GetComponent<basicbullet>();
        bsb.rbound=true;
        bsb.bound=false;
        bsb.chcolli(32,32);
        phase=0;
        phases[phase].enabled=true;
        picture pic=GetComponent<picture>();
        pic.loadimgsm("fairy_ex/fex",6,6);
    }
    
    // Update is called once per frame
    
    void Update()
    {
        datas self=GetComponent<datas>();
        datas np=phases[phase].GetComponent<datas>();
        if(np.rax==1){
            //return;
            np.rax=0;
            phases[phase].enabled=false;
            phase++;
            phase=phase%maxphase;
            phases[phase].enabled=true;
        }
        if(self.hp<0){
            dest();
        }
    }
    void dest(){
        SceneManager.LoadScene("OverGameScene");
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D cld){
        if(invulnerable){
            return;
        }
        datas self=GetComponent<datas>();
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

        if (sh != null){
            sh.updatehealth(cld.gameObject.name);
            
        }
    }
}