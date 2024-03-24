using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevelPhysics;

public class HeroMove : MonoBehaviour
{
    //人物速度
    private const float spd = 400f;
    public float HeroSpeed = 100.0f; 
    //控制左跑步动作的时间
    private float TimeRunLeft;
    //控制右跑步动作的时间
    private float TimeRunRight;
    private float TimeStatic;
    //用来存左跑步的图片
    public Sprite[] LeftRun; 
    //用来存右跑步的图片 
    public Sprite[] RightRun;  
    public Sprite[] StaticHeroR; 
    public Sprite[] StaticHeroL; 
    public Sprite[] EnterHero;
    //本对象的Render实例
    private SpriteRenderer HeroRender;  
    //
    private int LeftRunCnt = 1;
    private int RightRunCnt = 1;
    private int StaticCnt = 1;
    private int EnterCnt = 1;
    private bool isEnterDone = false;
    private bool statusRight;
    private BoxCollider2D boxCollider;

    void Awake()
    {    
        HeroSpeed = spd; 
    //控制左跑步动作的时间
        TimeRunLeft = -1f;
    //控制右跑步动作的时间
        TimeRunRight = -1f;
        TimeStatic = -1f;
        LeftRunCnt = 0;
        RightRunCnt = 0;
        StaticCnt = 0;
        EnterCnt = 0;
        HeroRender = GetComponent<SpriteRenderer>();
        transform.position = new Vector3 (-242, -272, 0);
        statusRight = true;
        StartCoroutine(EnterCoroutine()); //为了让开门动作先执行
    }

    void Start(){
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {  
        if (isEnterDone)
        {
            bool flag = true;
            Vector3 p = transform.position;

            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)){
                GameObject e = Instantiate(Resources.Load("prefabs/Flame") as GameObject);
                e.transform.localPosition = transform.localPosition;
                HoldMode();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)){UnHoldMode();}

            if (Input.GetKey(KeyCode.A)){
                p.x -= HeroSpeed * Time.smoothDeltaTime;
                if (p.x < -960){
                    p.x += HeroSpeed * Time.smoothDeltaTime * 10;
                }
                RUNLeft();
                statusRight = false;
                flag = !flag;
            }else if (Input.GetKey(KeyCode.D)){
                RUNRight();
                statusRight = true;
                p.x += HeroSpeed * Time.smoothDeltaTime;
                if (p.x > 530){
                    p.x -= HeroSpeed * Time.smoothDeltaTime * 10;
                }
                flag = !flag;
            }
            if (Input.GetKey(KeyCode.S)){
                // RUNLeft();
                // statusRight = false;
                p.y -= HeroSpeed * Time.smoothDeltaTime;
                if (p.y < -540){
                    p.y += HeroSpeed * Time.smoothDeltaTime * 10;
                }
                flag = !flag;
            }else if (Input.GetKey(KeyCode.W)){
                // RUNRight();
                // statusRight = true;
                p.y += HeroSpeed * Time.smoothDeltaTime;
                if (p.y > 540){
                    p.y -= HeroSpeed * Time.smoothDeltaTime * 10;
                }
                flag = !flag;
            }
            if (flag){
                StayStill(statusRight);
            }

            transform.position = p;
        }
    }

    private void RUNLeft(){
        if(Time.time - TimeRunLeft > 1/14f){
            LeftRunCnt = (LeftRunCnt + 1) % LeftRun.Length;
            HeroRender.sprite = LeftRun[LeftRunCnt];
            TimeRunLeft = Time.time;
        }
    }

    private void RUNRight(){
        if(Time.time - TimeRunRight > 1/14f){
            RightRunCnt = (RightRunCnt + 1) % RightRun.Length;
            HeroRender.sprite = RightRun[RightRunCnt];
            TimeRunRight = Time.time;
        }
    }

    private void StayStill(bool statusRight){
        // StaticCnt = 0;
        if(statusRight){
            if(Time.time - TimeStatic > 1/7f){
                StaticCnt = (StaticCnt + 1) % StaticHeroR.Length;
                HeroRender.sprite = StaticHeroR[StaticCnt];
                TimeStatic = Time.time;
            }
        }else{
            if(Time.time - TimeStatic > 1/7f){
                StaticCnt = (StaticCnt + 1) % StaticHeroL.Length;
                HeroRender.sprite = StaticHeroL[StaticCnt];
                TimeStatic = Time.time;
            }
        }
    }

    private void HoldMode(){
        HeroSpeed = spd * 0.25f;
        Color q = GetComponent<Renderer>().material.color;
        q.a = 0.2f;
        GetComponent<Renderer>().material.color = q;
        boxCollider.size = new Vector2(0.1f, 0.15f);
    }

    private void UnHoldMode(){
        HeroSpeed = spd;
        Color q = GetComponent<Renderer>().material.color;
        q.a = 1f;
        GetComponent<Renderer>().material.color = q;
        boxCollider.size = new Vector2(0.51f, 0.55f);
    }

    IEnumerator EnterCoroutine()
    {
    // 等待4秒，实现在Awake后的4秒开始执行
        // yield return new WaitForSeconds(4f);

        while (EnterCnt < EnterHero.Length) // 限制次数为 EnterHero.Length
        {
            HeroRender.sprite = EnterHero[EnterCnt];
            EnterCnt++;
            yield return new WaitForSeconds(1 / 8f); // 每1/8f调用一次
        }

        isEnterDone = true;
    }

    private bool HitWall(){
        Vector3 a = transform.position;
        if((a.x < -960) || (a.x > 530) || (a.y < -540) || (a.y > 540))return true;
        return false;
    }

}
