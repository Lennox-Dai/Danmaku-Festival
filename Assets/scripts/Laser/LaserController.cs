using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius;
    public bool isactive;
    private GameObject[] Lasers;
    void Start()
    {
        Lasers = new GameObject[8];
        radius = 100f;
        isactive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isactive)StartCoroutine(createlaser());
    }

    public IEnumerator createlaser(){
        isactive = true;
        GameObject e = Instantiate(Resources.Load("prefabs/warning") as GameObject);
        transform.position = new Vector3 (Random.Range(-653f, 278f), Random.Range(-366f, 291f), 0);
        e.transform.position = transform.position;
        yield return new WaitForSeconds(5);
        for (int i = 0; i < Lasers.Length; i++){
            Lasers[i] = Instantiate(Resources.Load("prefabs/laser") as GameObject);
            Lasers[i].transform.position = transform.position + new Vector3(radius * Mathf.Cos(2f * (float)i / (float)Lasers.Length * Mathf.PI), radius * Mathf.Sin(2f * (float)i /(float)Lasers.Length * Mathf.PI), 0);
            Lasers[i].transform.up = new Vector3(Mathf.Cos(2f * (float)i / (float)Lasers.Length * Mathf.PI), Mathf.Sin(2f * (float)i / (float)Lasers.Length * Mathf.PI), 0);
        }  
    }

}
