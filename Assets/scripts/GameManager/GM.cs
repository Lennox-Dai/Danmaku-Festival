using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public static GM GameManage = null;
    public HeroMove h = null;
    public HeroCrush c = null;
    public NormalController n = null;
    public SHAKE s = null;


    void Start()
    {
        GM.GameManage = this;
        Debug.Assert(h != null);
        Flame.getHero(h);
        Resource1.getController(n); 
        Resource2.getController(n); 
        Resource3.getController(n); 
        goldobj.getController(n);
        BombScript.getHero(c);
        BulletScript.getHero(c);
        ShieldScript.getHero(c);
        HeartController.getHero(c);
        NormalBullet.getHero(c);
        NormalController.getHero(c);
        NormalController.getmove(h);
        QBehav.getController(n);
        Blink.getController(n);
        phase_shift.getSHAKE(s);
        healthbar.getSHAKE(s);
        BackbarScript.getSHAKE(s);
        BackMenueScript.getHero(c);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
