using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picture : MonoBehaviour
{
    // Start is called before the first frame update
    Sprite[] stand=new Sprite[10];
    Sprite[] move=new Sprite[10];
    float ltime=0;
    int cnt=0;
    int lens=0,lenm=0;
    void Start()
    {
        if(lens>0){
            return;
        }
        lens=4;
        lenm=4;
        for(int i=0;i<lens;i++){
            stand[i]=Resources.Load<Sprite>("enemy/fairy_y/fy_"+(i+1)) as Sprite;
            if(stand[i]==null){
                Debug.Log("kksk");
            }
        }
        for(int i=0;i<lenm;i++){
            move[i]=Resources.Load<Sprite>("enemy/fairy_y/fym_"+(i+1)) as Sprite;
            if(stand[i]==null){
                Debug.Log("kksk");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        basicbullet basb=gameObject.GetComponent<basicbullet>();
        if(Time.time-ltime>0.2){
            ltime=Time.time;
            cnt++;
            float v=gameObject.GetComponent<datas>().v;
            if(v!=0){
                basb.chimg(move[cnt%lenm]);
                float deg=gameObject.GetComponent<datas>().deg;
                float muls=3;
                if(deg<90&&deg>-90){
                    basb.chscale(1f*muls,1f*muls);
                }
                else{
                    basb.chscale(-1f*muls,1f*muls);
                }
            }
            else{
                basb.chimg(stand[cnt%lens]);
            }
        }
    }
    public void chimgs(Sprite[] s,int len1,Sprite[] m,int len2){
        for(int i=0;i<len1;i++){
            stand[i]=s[i];
        }
        lens=len1;
        for(int i=0;i<len2;i++){
            move[i]=m[i];
        }
        lenm=len2;
    }
    public void loadimgsm(string _name,int len1,int len2){
        Sprite[] imgs=new Sprite[10];
        Sprite[] imgm=new Sprite[10];
        for(int i=0;i<len1;i++){
            imgm[i]=Resources.Load<Sprite>("enemy/"+_name+"m_"+(i+1)) as Sprite;
            if(imgm[i]==null){
                Debug.Log(_name);
            }
        }
        for(int i=0;i<len2;i++){
            imgs[i]=Resources.Load<Sprite>("enemy/"+_name+"s_"+(i+1)) as Sprite;
        }
        chimgs(imgs,len1,imgm,len2);
    }
}
