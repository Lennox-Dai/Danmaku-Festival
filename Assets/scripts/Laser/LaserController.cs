using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius;
    public bool isactive;
    private GameObject[] Lasers;
    public bool framed=false;
    void Start()
    {
        Lasers = new GameObject[8];
        radius = 200f;
        isactive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(framed==true){
            return;
        }
        basicbullet bsb=GetComponent<basicbullet>();
        bsb.chv(0);
        framed=true;
        isactive=false;
        if(!isactive)StartCoroutine(createlaser());
    }

    public IEnumerator createlaser(){
        isactive = true;
        GameObject e = Instantiate(Resources.Load("prefabs/warning") as GameObject);
        basicbullet bsb=GetComponent<basicbullet>();
        float x=Random.Range(-653f, 278f),y=Random.Range(-366f, 291f);
        bsb.moveto(x,y,60);
        Vector3 vec = new Vector3 (x, y, 0);
        e.transform.position = vec;
        yield return new WaitForSeconds(5);
        for (int i = 0; i < Lasers.Length; i++){
            Lasers[i] = Instantiate(Resources.Load("prefabs/laser") as GameObject);
            LaserScript lc=Lasers[i].GetComponent<LaserScript>();
            lc.getcontroller(gameObject.GetComponent<LaserController>());
            Lasers[i].transform.position = transform.position + new Vector3(radius * Mathf.Cos(2f * (float)i / (float)Lasers.Length * Mathf.PI), radius * Mathf.Sin(2f * (float)i /(float)Lasers.Length * Mathf.PI), 0);
            Lasers[i].transform.up = new Vector3(Mathf.Cos(2f * (float)i / (float)Lasers.Length * Mathf.PI), Mathf.Sin(2f * (float)i / (float)Lasers.Length * Mathf.PI), 0);
        }  
    }

}
