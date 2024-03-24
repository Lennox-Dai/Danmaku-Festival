using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    static private HeroCrush h = null;
    bool isDestroying = false;
    private float ImgTime;
    private int Imgcnt1;
    private int Imgcnt;
    public float damage;    
    public Sprite[] FlyBomb;
    public Sprite[] LandBomb;
    public SpriteRenderer BombRender;
    public Vector3 TargetP;//这个值是鼠标点击的地方
    private Vector3 curPosition;
    private float lerptime;
    private float rate;
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
        damage = 500f;
        rate = 0.01f;
        lerptime = -100f;
    }

    // Update is called once per frame
    void Update()
    {
        updateimg();
        if ((Vector3.Distance(curPosition, TargetP) > 100) && (Time.time - lerptime > 0.01f)){
            // transform.position = Vector3.SmoothDamp(transform.position, TargetP, ref velocity, Time.smoothDeltaTime);
            curPosition = Vector3.Lerp(curPosition, TargetP, rate) + new Vector3(Random.Range(-5f, 5), Random.Range(-5f, 5), 0);
            lerptime = Time.time;
            transform.position = curPosition;
        }
        if (HitWall()){
            Debug.Log("hitwall");
            MyDestory();
        }
    }

    //TODO 加上和谁碰撞
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("with:"+collision.gameObject.name);
        MyDestory();
    }

    private void updateimg(){
        if (Time.time - ImgTime > 0.8){
            Imgcnt1 = (Imgcnt1 + 1) % FlyBomb.Length;
            BombRender.sprite = FlyBomb[Imgcnt1];
            ImgTime = Time.time;
        }
    }
    private bool HitWall(){
        Vector3 a = transform.position;
        if((a.x < -960) || (a.x > 530) || (a.y < -540) || (a.y > 540))return true;
        return false;
    }

    private void MyDestory(){
        if (isDestroying) return;

        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null) 
        {
            collider.enabled = false;
        }

        isDestroying = true;
        StartCoroutine(boomimg());
    }
    private IEnumerator boomimg(){
        Imgcnt = 0;
        while(Imgcnt < LandBomb.Length) {
            BombRender.sprite = LandBomb[Imgcnt];
            Imgcnt++;
            yield return new WaitForSeconds(0.3f);
        }
        Destroy(transform.gameObject);
    }
}
