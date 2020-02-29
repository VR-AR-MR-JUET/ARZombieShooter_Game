using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{ 
    public static int count;
    public GameObject damage;
    public Image damagedimage;
    private void Start()
    {
        count = 0;
        damage.SetActive(false);
    }
    public void healthdamage()
    {
        Handheld.Vibrate();
        damage.SetActive(true);
        damagedimage.CrossFadeAlpha(0.3f, 0.2f, true);
        count++;
    }public void middamage()
    {
       
    }
    public void enddamage()
    {
        damage.SetActive(false);
    }
}
