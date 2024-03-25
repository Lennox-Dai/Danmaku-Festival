using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar : MonoBehaviour
{
    public Sprite[] barcolor;
    private SpriteRenderer HealthRender;
    static private datas h = null;
    static private SHAKE sh = null;
    static public void getbossdata(datas g){
        h = g;
    } 
    static public void getSHAKE(SHAKE g){
        sh = g;
    } 


    private float inilenth;
    private Vector3 p;
    private float healSpeed = 1600f;
    // Start is called before the first frame update
    void Start()
    {
        // transform.position = new Vector3 (-741f, 465f, 30f);
        // inilenth = 3380.19f;
        // p = transform.position;
        // HealthRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = sh.transform.position;
        // // p.x = inilenth * h.hp / h.mhp;        
        // if (p.x <= 0){
        //     if (h.phase > 3){
        //         Destroy(transform.gameObject);
        //     }
        //     HealthRender.sprite = barcolor[h.phase - 1];
        //     while (p.x < inilenth){
        //         p.x += healSpeed * Time.smoothDeltaTime;
        //     }
        //     p.x = inilenth;
        // }
        // transform.position = p;
    }

}
