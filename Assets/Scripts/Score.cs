using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
   // private int count=0;
    
    public  Text text;

    public static int kill = 0;
    private int count;
    public static bool isDead = false;
    void Start()
    {
       // text = ameObject.Find("Score");
        count = 1;
        kill = 0;
        //counter = 0;
    }

    void Update()
    {
       // isDead = Movement.dead;
        if (isDead == true)
        {
            dead();
            
            isDead = false;
            if (count == 3)
            {
                count = 1;
                Difficulty.dead = true;
            }
            count++;
        }
    }
    public void dead()
    {
        kill++;
        text.text = "Kill : " + kill;
        
    }

}
