using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave_part : MonoBehaviour
{
    // Start is called before the first frame update
    float lastti=0f;
    float frame=0.016f;
    float deg=0;
    float degv=0;
    int timer=0;
    GameObject bullet1=null;
    bool moving=false;
    float cx=-240,cy=0,lx=735,ly=540;
    void Start()
    {
        if(ly==1&&lx==1){

        }
        transform.localPosition=new Vector3(cx,cy+ly/2,0);
        bullet1=Resources.Load("enemy/prefab/bulletclass") as GameObject;
        Sprite grain=Resources.Load<Sprite>("enemy/grain1") as Sprite;
        bullet1.GetComponent<basicbullet>().chimg(grain);
    }
    float t1=480;
    float t2=960;
    // Update is called once per frame
    void Update()
    {
        if(Time.time-lastti>frame){
            timer++;
            lastti=Time.time;
        }
        else{
            return;
        }
        if(timer<t1){
            degv+=0.05f;
            deg+=degv;
            if(timer%2==0&&moving==false){
                for (int i=0;i<=8;i++){
                    GameObject bul=Instantiate(bullet1);
                    basicbullet basb=bul.GetComponent<basicbullet>();
                    basb.chplace(transform.localPosition.x,transform.localPosition.y);
                    basb.chrot(deg+i*360/8);
                    basb.chdeg(deg+i*360/8);
                    basb.chv(3f);
                    basb.chscale(2,2);
                }
            }
        }
        else if(timer>=t1&&timer<t2){

        }
        else{
            timer=0;
        }
    }
}
