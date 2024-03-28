using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    private float FlashTime;
    private int Flashcnt;
    public Sprite[] Fire;
    public SpriteRenderer FireRender;
    static private HeroMove h = null;
    static public void getHero(HeroMove g){
        h = g;
    } 
    void Start()
    {
        FireRender = GetComponent<SpriteRenderer>();
        FlashTime = -1f;
        Flashcnt = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.RightShift)){
            if(Time.time -  FlashTime > 1/20f){
                Flashcnt = (Flashcnt + 1) % Fire.Length;
                FireRender.sprite = Fire[Flashcnt];
                FlashTime = Time.time;
                transform.position = h.transform.position;
        }
        }else{
            Destroy(transform.gameObject);
        }
    }
}
