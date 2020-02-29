using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public static int count;
    private float time;
    public static bool dead;
    void Start()
    {
        count = 2;
        dead = false;
    }
    void Update()
    {
        //Debug.Log(count + "healthout");
        if (dead)
        {
            upgrade();
            dead = false;
        }
        
    }
    private void upgrade()
    {
        {
            count++;
            Debug.Log(count + "healthincreased");
        }
    }
    
    
}
