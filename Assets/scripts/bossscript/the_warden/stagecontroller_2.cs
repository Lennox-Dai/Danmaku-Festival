using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stagecontroller_2 : MonoBehaviour
{
    // Start is called before the first frame update
    int timer=0;
    float frame=0.0166f;
    float lastti=0;
    GameObject enemy_drop;
    GameObject enemy_melee;
    GameObject enemy_snipe;
    GameObject boss2;
    GameObject b1;
    bool finished=false;
    float cx=-240,cy=0,lx=735,ly=540;
    void Start()
    {
        enemy_drop=Resources.Load("enemy/prefab/enemy_drop") as GameObject;
        enemy_melee=Resources.Load("enemy/prefab/enemy_melee") as GameObject;
        enemy_snipe=Resources.Load("enemy/prefab/enemy_snipe") as GameObject;
        boss2=Resources.Load("enemy/prefab/boss_2_warden") as GameObject;
    }
    
    // Update is called once per frame
    //float t1=4f;
    void Update()
    {
        //return;
        if(Time.time-lastti>frame){
            timer++;
            lastti=Time.time;
        }
        else{
            return;
        }
        if(timer==60){
            GameObject e1=Instantiate(boss2);
            datas datas = e1.GetComponent<datas>();
            GameObject Backbar = Instantiate(Resources.Load("prefabs/backbar") as GameObject);
            GameObject Frontbar = Instantiate(Resources.Load("prefabs/frontbar") as GameObject);
            healthbar.getbossdata(datas);
        }
    }
}
