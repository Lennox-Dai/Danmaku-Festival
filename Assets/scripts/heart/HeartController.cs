using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    
    private GameObject[] Hearts;
    private HeartScript[] hs;
    private float BeatTime;
    private int health;
    static private HeroCrush h = null;
    static public void getHero(HeroCrush g){
        h = g;
    }
    void Start()
    {
        health = 13;
        BeatTime = -100f + Time.time;
        Hearts = new GameObject[13];
        hs = new HeartScript[13];
        for (int i = 0; i < Hearts.Length; i++){
            Hearts[i] = Instantiate(Resources.Load("prefabs/heart") as GameObject);
        }
        Hearts[0].transform.localPosition = new Vector3 (643, 334, 0);
        hs[0] = Hearts[0].GetComponent<HeartScript>();
        Hearts[1].transform.localPosition = new Vector3 (740, 334, 0);
        hs[1] = Hearts[1].GetComponent<HeartScript>();
        Hearts[2].transform.localPosition = new Vector3 (825, 334, 0);
        hs[2] = Hearts[2].GetComponent<HeartScript>();
        Hearts[3].transform.localPosition = new Vector3 (608, 256, 0);
        hs[3] = Hearts[3].GetComponent<HeartScript>();
        Hearts[4].transform.localPosition = new Vector3 (695, 256, 0);
        hs[4] = Hearts[4].GetComponent<HeartScript>();
        Hearts[5].transform.localPosition = new Vector3 (788, 256, 0);
        hs[5] = Hearts[5].GetComponent<HeartScript>();
        Hearts[6].transform.localPosition = new Vector3 (878, 256, 0);
        hs[6] = Hearts[6].GetComponent<HeartScript>();
        Hearts[7].transform.localPosition = new Vector3 (643, 177, 0);
        hs[7] = Hearts[7].GetComponent<HeartScript>();
        Hearts[8].transform.localPosition = new Vector3 (740, 177, 0);
        hs[8] = Hearts[8].GetComponent<HeartScript>();
        Hearts[9].transform.localPosition = new Vector3 (825, 177, 0);
        hs[9] = Hearts[9].GetComponent<HeartScript>();
        Hearts[10].transform.localPosition = new Vector3 (698, 101, 0);
        hs[10] = Hearts[10].GetComponent<HeartScript>();
        Hearts[11].transform.localPosition = new Vector3 (791, 101, 0);
        hs[11] = Hearts[11].GetComponent<HeartScript>();
        Hearts[12].transform.localPosition = new Vector3 (740, 28, 0);
        hs[12] = Hearts[12].GetComponent<HeartScript>();
        for (int i = 0; i < hs.Length; i++){
            hs[i].BirthTimeAdd((float)i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        health = h.gethealth();
        for (int i = 0; i < health; i++){
            hs[i].TurnAlive();
        }
        for (int i = health; i < 13; i++){
            hs[i].TurnDead();
        }
        // if (Time.time - BeatTime > 8f){
        //     for (int i = 0; i < Hearts.Length; i++){    
        //         Debug.Log("start leap");
        //         StartCoroutine(hs[i].Leap());
        //     }
        //     BeatTime = Time.time;
        // }

    }
}
