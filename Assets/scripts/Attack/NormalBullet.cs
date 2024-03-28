using System.Collections;
using System.Collections.Generic;
// using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    static private HeroCrush h = null;
    public bool dir;
    public float damage;    
    public SpriteRenderer BombRender;
    public Vector3 TargetP;//这个值是鼠标点击的地方
    private float speed;
    private Vector3 curPosition;
    private Vector3 Dir;
    private int mode;
    static public void getHero(HeroCrush g){
        h = g;
    } 
    void Start()
    {
        TargetP.z = 0;
        // Debug.Log(TargetP);
        transform.position = h.transform.position;
        curPosition = transform.position;
        mode = PlayerPrefs.GetInt("Difficulty");
        if (mode == 1){
            damage = 100f;
        }else if(mode == 2){
            damage = 50f;
        }else if(mode == 3){
            damage = 30f;
        }
        // damage = 50f;
        speed = 800f;
        Dir = (TargetP - curPosition).normalized;
        transform.up = new Vector3(Dir.y, -Dir.x, 0);
    }

    // Update is called once per frame
    void Update()
    {
        travel();
        if (HitWall()){
            // Debug.Log("hitwall");
            Destroy(transform.gameObject);
        }
    }

    //TODO 加上和谁碰撞
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("with:"+collision.gameObject.name);
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
        curPosition += Dir * speed * Time.smoothDeltaTime;
        transform.position = curPosition;
        // Debug.Log("c " + TargetP);
    }
}
