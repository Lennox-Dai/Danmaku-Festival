using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHAKE : MonoBehaviour
{
    static private datas h = null;
    static public void getbossdata(datas g){
        h = g;
    } 
    private ShakePosition mShake = new ShakePosition(5, 0.5f);

    void Start()
    {
        transform.position = new Vector3 (-741f, 465f, 35f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updatehealth(string bulletname){
            if (bulletname == "bomb"){
                bloodshake();
            }
    }

    private void bloodshake(){
        if (!mShake.ShakeDone())
        {
            transform.position = mShake.UpdateShake();
        }
    }
    
}
