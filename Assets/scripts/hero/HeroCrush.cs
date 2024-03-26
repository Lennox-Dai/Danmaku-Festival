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
    private SpriteRenderer HeroRender;  
    private bool finish;
    public bool once;

    // Start is called before the first frame update
    void Start()
    {
        health = 13;
        counttime = Time.time;
        finish = false;
        once = true;
        HeroRender = GetComponent<SpriteRenderer>();
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
            GameObject e = Instantiate(Resources.Load("prefabs/Shield") as GameObject);
            ShieldScript a =  e.GetComponent<ShieldScript>();
            GetComponent<AudioSource>().Play();
            a.lasting = 2f;
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

}


