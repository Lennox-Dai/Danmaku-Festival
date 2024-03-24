using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    static private HeroCrush h = null;
    bool isDestroying = false;
    private float ImgTime;
    public bool dir;
    private int Imgcnt;
    public float damage;    
    public SpriteRenderer BombRender;
    public Vector3 TargetP;//这个值是鼠标点击的地方
    private float speed;
    private Vector3 curPosition;
    private Vector3 Dir;
    private Vector3 Trans;
    private float starttime;
    private float bias;//偏移量
    private float freq;//偏移频率
    private Vector3 ori;
    static public void getHero(HeroCrush g){
        h = g;
    } 
    void Start()
    {
        isDestroying = false;
        BombRender = GetComponent<SpriteRenderer>();
        TargetP.z = 0;
        // Debug.Log(TargetP);
        transform.position = h.transform.position;
        curPosition = transform.position;
        damage = 5f;
        speed = 800f;
        starttime = Time.time;
        bias = 1000f;
        freq = 15f;
        Dir = (TargetP - curPosition).normalized;
        Trans = new Vector3(Dir.y, -Dir.x, 0);
        if (dir)Trans = -Trans;
    }

    // Update is called once per frame
    void Update()
    {
        travel();
        if (HitWall()){
            Debug.Log("hitwall");
            Destroy(transform.gameObject);
        }
    }

    //TODO 加上和谁碰撞
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            Destroy(transform.gameObject);
        }
    }

    private bool HitWall(){
        Vector3 a = transform.position;
        if((a.x < -960) || (a.x > 530) || (a.y < -540) || (a.y > 540))return true;
        return false;
    }


    private void travel(){
        ori = Dir * speed + bias * Trans * Mathf.Cos(freq * (Time.time - starttime));
        transform.up = -ori;
        curPosition += ori * Time.smoothDeltaTime;
        transform.position = curPosition;
    }
}
