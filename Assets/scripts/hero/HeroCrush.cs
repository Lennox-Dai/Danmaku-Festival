using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevelPhysics;

public class HeroCrush : MonoBehaviour
{
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 13;
    }
    public int gethealth(){
        return health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0){
            Application.Quit();
        }
    }

    
    // TODO 人和子弹碰撞问题
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("resources"))
        {
            health--;
            GameObject e = Instantiate(Resources.Load("prefabs/Shield") as GameObject);
            ShieldScript a =  e.GetComponent<ShieldScript>();
            a.lasting = 2f;
        }
    }

}


