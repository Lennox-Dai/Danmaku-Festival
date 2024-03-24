using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    private bool increase;
    private float increase_speed;
    static private NormalController h = null;
    static public void getController(NormalController g){
        h = g;
    } 
    void Start()
    {
        increase = true;
        increase_speed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = transform.localScale;
        float chg = increase_speed * Time.smoothDeltaTime;
        if(increase){
            p += new Vector3(chg, chg, 0);
            if(p.x >= 125){
                increase = false;
            }
        }else{
            p -= new Vector3(chg, chg, 0);
            if(p.x <= 100){
                increase = true;
            }
        }
        transform.localScale = p;
        if(!h.getobtain()){
            Destroy(transform.gameObject);
        }

    }
}
