using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHAKE : MonoBehaviour
{
    private ShakePosition mShake = new ShakePosition(5, 0.5f);
    static public Vector3 p; 

    void Start()
    {
        transform.position = new Vector3 (-741f, 465f, 35f);
        p = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        bloodshake();
    }

    public void updatehealth(string bulletname){
            if (bulletname == "bomb(Clone)"){
                Debug.Log(1);
                mShake.SetShakeMagnitude(new Vector2(70, 70), transform.position);
            }
    }

    private void bloodshake(){
        if (!mShake.ShakeDone())
        {
            Debug.Log("Cicling");
            transform.position = mShake.UpdateShake();
        }
    }
    
}
