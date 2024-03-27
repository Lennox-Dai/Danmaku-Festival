using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    static private LaserController l = null;
    public void getcontroller(LaserController g){
        l = g;
    }
    private float radius;
    private float rotspd;
    private float movspd;
    private float angle;
    void Start()
    {
        radius = l.radius;
        rotspd = 360f;
        movspd = 150f;
        angle = Mathf.Atan(transform.up.y / transform.up.x) * 180f / Mathf.PI;
    if (transform.up.x < 0){
        angle -= 180f;
    }
        // Debug.Log(angle);
    }

    // Update is called once per frame
    void Update()
    {
        if (radius >= 1000){
            //l.isactive = false;
            datas np=l.GetComponent<datas>();
            np.rax=1;
            l.framed=false;
            Destroy(transform.gameObject);
        }
        radius += movspd * Time.smoothDeltaTime;
        angle += rotspd * Time.smoothDeltaTime;
        transform.position = new Vector3(radius * Mathf.Cos(angle / 180f * Mathf.PI), radius * Mathf.Sin(angle / 180f * Mathf.PI), 0) + l.transform.position;
        transform.up = new Vector3(Mathf.Cos(angle / 180f * Mathf.PI), Mathf.Sin(angle / 180f * Mathf.PI), 0);
    }
}
