using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    
    static private HeroCrush h = null;
    static public void getHero(HeroCrush g){
        h = g;
    } 
    private Text scoreTxt;
    private float score = 0;

    private float Timer;
    public int prehit;

    private float perScore = 10;
    void Start()
    {
        scoreTxt = GetComponent<Text>();
        score = 0;
        scoreTxt.text = "分数：0";
        ResetPerScore();
        prehit = 0;
    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 0.1)
        {
            Timer = 0;
            if (score < 10000000)
            {
                score += perScore;
                SetScoreText(score);
                perScore += 2;
                if (h.hittimes != prehit){
                    // Debug.Log("a");
                    perScore = 10;
                    prehit = h.hittimes;
                }
                if (perScore >= 1000)
                {
                    perScore = 1000;
                }
            }
        }
    }

    /// <summary>
    /// ���÷����ı�
    /// </summary>
    /// <param name="score"></param>
    public void SetScoreText(float score)
    {
        scoreTxt.text = "分数：" + score;
    }

    /// <summary>
    /// ����ÿ�����ӵķ���
    /// </summary>
    public void ResetPerScore()
    {
        perScore = 10;
    }

    /// <summary>
    /// ���ӷ���
    /// </summary>
    /// <param name="score"></param>
    public void AddScore(float score)
    {
        this.score += score;
        SetScoreText(this.score);
    }
}
