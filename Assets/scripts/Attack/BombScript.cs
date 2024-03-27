using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    static private HeroCrush h = null;
    bool isDestroying = false;
    private float ImgTime;
    private int Imgcnt;
    private int Imgcnt1;
    public float damage;    
    public Sprite[] FlyBomb;
    public Sprite[] LandBomb;
    public SpriteRenderer BombRender;
    public Vector3 TargetP;//这个值是鼠标点击的地方
    private Vector3 curPosition;
    private float lerptime;
    private float rate;
    private int mode;
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
        mode = PlayerPrefs.GetInt("Difficulty");
        if (mode == 1){
            damage = 500f;
            transform.localScale = new Vector3(500f, 500f, 1f);
        }else if(mode == 2){
            damage = 200f;
            transform.localScale = new Vector3(250f, 250f, 1f);
        }else if(mode == 3){
            damage = 100f;
            transform.localScale = new Vector3(250f, 250f, 1f);
        }
        // damage = 250f;
        rate = 0.05f;
        lerptime = -100f;
    }

    // Update is called once per frame
    void Update()
    {
        updateimg();
        if ((Vector3.Distance(curPosition, TargetP) > 30) && (Time.time - lerptime > 0.01f)){
            // transform.position = Vector3.SmoothDamp(transform.position, TargetP, ref velocity, Time.smoothDeltaTime);
            curPosition = Vector3.Lerp(curPosition, TargetP, rate) + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
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
        if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            MyDestory();
        }
    }

    private void updateimg(){
        if (Time.time - ImgTime > 0.3){
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
            yield return new WaitForSeconds(0.2f);
        }
        Destroy(transform.gameObject);
    }
}
