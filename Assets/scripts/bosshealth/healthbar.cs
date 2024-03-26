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
    private float healSpeed = 1f;
    private int lastphase;
    // Start is called before the first frame update
    void Start()
    {
        HealthRender = GetComponent<SpriteRenderer>();
        transform.position = new Vector3 (-741f, 465f, -8f);
        inilenth = 3380.19f;
        healSpeed = 100f;
        p = transform.localScale;
        lastphase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (h == null){
            Destroy(transform.gameObject);
        }
        transform.position = sh.transform.position;
        p.x = inilenth * h.hp / h.mhp;        
        if (lastphase != h.phase){
            if (h.phase > 3){
                Destroy(transform.gameObject);
            }
            HealthRender.sprite = barcolor[h.phase - 1];
            Debug.Log(p);
            p.x = 0;
            while (p.x < inilenth){
                Debug.Log("Healing");
                p.x += healSpeed * Time.smoothDeltaTime;
                transform.localScale = p;
            }
            // StartCoroutine(HealSmoothly());
            p.x = inilenth;
        }
        lastphase = h.phase;
        transform.localScale = p;
    }

    IEnumerator HealSmoothly()
    {
        while (p.x < inilenth)
        {
            Debug.Log("Healing");
            p.x += healSpeed * Time.smoothDeltaTime;
            transform.localScale = p;
            yield return null; // Wait for 0.1 seconds
        }
    }
}
