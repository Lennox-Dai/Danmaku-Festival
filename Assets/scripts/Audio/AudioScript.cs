using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool flag = false;
    private AudioSource m_AudioSource;
    public Sprite[] Audio;
    public SpriteRenderer AudioRender;
    public int cnt;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonClick);
        m_AudioSource = gameObject.GetComponent<AudioSource>();
        AudioRender = GetComponent<SpriteRenderer>();
        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonClick()
    {
        flag = !flag;
        if (flag)
        {
            m_AudioSource.Pause();
        }
        else
        {
            m_AudioSource.UnPause();
        }
        cnt = (cnt + 1) % Audio.Length;
        AudioRender.sprite = Audio[cnt];
    }
}
