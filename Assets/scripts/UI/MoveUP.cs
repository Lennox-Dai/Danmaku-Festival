using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUP : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    void Start()
    {
        speed = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q)){
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            speed *= 10;
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            speed /= 10;
        }
        Vector3 p = transform.position;
        p.y += speed * Time.smoothDeltaTime;
        transform.position = p;
    }
}
