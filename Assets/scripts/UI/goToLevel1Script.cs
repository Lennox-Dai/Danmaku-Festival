using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class goToLevel1Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnClick()
    {
        PlayerPrefs.SetInt("Difficulty", 1);
        SceneManager.LoadScene("SceneChoose");//level1为我们要切换到的场景
    }
}
