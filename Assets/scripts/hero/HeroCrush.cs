using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevelPhysics;
using UnityEngine.SceneManagement;

public class HeroCrush : MonoBehaviour
{
    public int health;
    public float counttime;
    public Sprite[] dead; 
    public Sprite hitted;
    public Sprite nothit;  
    private SpriteRenderer HeroRender;  
    private bool finish;
    public bool once;
    public int mode;
    public bool Hiit;
    public int hittimes;

    // Start is called before the first frame update
    void Start()
    {
        mode = PlayerPrefs.GetInt("Difficulty");
        health = 13;
        counttime = Time.time;
        finish = false;
        once = true;
        HeroRender = GetComponent<SpriteRenderer>();
        Hiit = false;
        hittimes = 0;
    }
    public int gethealth(){
        return health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0){
            if (once)StartCoroutine(GoDead());
            if (finish){
                counttime = Time.time - counttime;
                SceneManager.LoadScene("OverScene");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("resources"))
        {
            health--;
            hittimes++;
            Hiit = true;
            GameObject e = Instantiate(Resources.Load("prefabs/Shield") as GameObject);
            ShieldScript a =  e.GetComponent<ShieldScript>();
            GetComponent<AudioSource>().Play();
            a.lasting = 2f;
            StartCoroutine(Hit());
        }
    }

    private IEnumerator GoDead(){
        once = false;
        for (int i = 0; i < dead.Length; i++){
            HeroRender.sprite = dead[i];
            yield return new WaitForSeconds(0.2f);
        }
        finish = true;
    }

    private IEnumerator Hit(){
        HeroRender.sprite = hitted;
        yield return new WaitForSeconds(0.5f);
        HeroRender.sprite = nothit;
        Hiit = false;
    }

}


