using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    // SceneManager scenemanager;
    public Image health,d;
    public GameObject damage1, damage2, damage3, damage4;
    public static bool startDamage,middamage,enddamage;
    //public GameObject damaged;
    private int count;
    void Start()
    {
        count = 0;
        //damage1.SetActive(false);
        //damage2.SetActive(false);
      //  damage3.SetActive(false);
        

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerHealth.count > count)
        {
            
            
            count = PlayerHealth.count;
            if (count <= 10)
            {
                
                health.fillAmount = 1 - (count * 0.1f);
            }
            else 
            {
                PlayerPrefs.SetInt("tempscore",Score.kill);
                SceneManager.LoadScene("GameOver");
            }
        }
        
    /*    if (startDamage == true)
        {
            stdamage();
            startDamage = false;
        }
        if (enddamage == true)
        {
            // d.CrossFadeAlpha(0f, 0.3f, true);
            endamage();
            enddamage = false;
            
        }*/
    }
   /* public void stdamage()
    {
        damage4.SetActive(true);
       // d.CrossFadeAlpha(0.3f, 0.3f, false);
        
    }
    public void endamage()
    {
        
        
        //d.CrossFadeAlpha(0.3f, 0.3f, false);
        damage4.SetActive(false);

    }*/
}
