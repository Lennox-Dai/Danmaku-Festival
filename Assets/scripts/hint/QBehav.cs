using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QBehav : MonoBehaviour
{
    static private NormalController h = null;
    static public void getController(NormalController g){
        h = g;
    } 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!h.getobtain()){
            Destroy(transform.gameObject);
        }
    }
}
