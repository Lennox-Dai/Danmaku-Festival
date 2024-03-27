using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class BackMenueScript : MonoBehaviour
{
    // static private HeroCrush h = null;
    // static public void getHero(HeroCrush g){
    //     h = g;
    // } 
    private float time;
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
        // time = h.counttime;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick()
    {
        SceneManager.LoadScene("MainMenuScene");//level1为我们要切换到的场景
    }
}
