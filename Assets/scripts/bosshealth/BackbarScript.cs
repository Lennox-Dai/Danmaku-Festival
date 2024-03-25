using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackbarScript : MonoBehaviour
{
    static private SHAKE sh = null;
    static public void getSHAKE(SHAKE g){
        sh = g;
    } 
    void Start()
    {
        transform.position = new Vector3 (-741f, 465f, 35f);
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 p = sh.transform.position;
        // p.z += 5;
        // transform.position = p;
    }
}
