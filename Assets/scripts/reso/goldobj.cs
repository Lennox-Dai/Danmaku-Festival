using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class goldobj : MonoBehaviour
{
    bool increase = true;
    private float increase_speed;
    private int Check4Once;
    public bool fix;
    private int on;
    static private NormalController h = null;
    static public void getController(NormalController g){
        h = g;
    } 
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(50, 50, 2);
        increase = true;
        Check4Once = 1;
        increase_speed = 30.0f;
        fix = false;
        on = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!fix){
            ChangeSize();
        }else{
            if(on == 1){
                transform.position = h.transform.position + new Vector3(-17, 50, 0);
            }else if(on ==2){
                transform.position = h.transform.position + new Vector3(17, 50, 0);
            }
            if (h.getobjNum() == 2){
                Destroy(transform.gameObject);
            }
        }

        if(h.getchoose()){
            fix = true;
            transform.localScale = new Vector3(50, 50, 2);
            if (Check4Once != 0){
                on = h.getobjNum();
                Check4Once--;
            }
        }
    }

    private void ChangeSize(){
        on = h.getobjNum();
        Vector3 p = transform.localScale;
        float chg = increase_speed * Time.smoothDeltaTime;
        if(increase){
            p += new Vector3(chg, chg, 0);
            if(p.x >= 100){
                increase = false;
            }
        }else{
            p -= new Vector3(chg, chg, 0);
            if(p.x <= 50){
                increase = true;
            }
        }
        if(on == 0){
            transform.position = h.transform.position + new Vector3(-17, 50, 0);
        }else{
            transform.position = h.transform.position + new Vector3(17, 50, 0);
        }
        transform.localScale = p;
        if(!h.intersect){
            Destroy(transform.gameObject);
        }
    }
}
