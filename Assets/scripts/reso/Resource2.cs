using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource2 : MonoBehaviour
{
    public bool mindactivate;
    private float deathtime;
    private float renewtime;
    public Sprite[] goldmind;
    public SpriteRenderer GoldRender;

    static private NormalController h = null;
    static public void getController(NormalController g){
        h = g;
    } 
    void Start()
    {
        GoldRender = GetComponent<SpriteRenderer>();
        mindactivate = true;
        deathtime = 0;
        renewtime = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!mindactivate && (Time.time - deathtime > renewtime)){
            mindactivate = true;
            GoldRender.sprite = goldmind[0];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hero"){
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hero"){
            // Debug.Log("obtainable:" + h.getobtain());
        }
    }

    public void collapse(){
        mindactivate = false;
        deathtime = Time.time;
        GoldRender.sprite = goldmind[1];
    }

    public void hint(){
        GameObject q = Instantiate(Resources.Load("prefabs/Q") as GameObject);
        q.transform.localPosition = transform.localPosition + new Vector3 (0, 125, 0);
        GameObject box = Instantiate(Resources.Load("prefabs/HintQbox") as GameObject);
        box.transform.localPosition = transform.localPosition + new Vector3 (0, 125, 0);
    }

}
