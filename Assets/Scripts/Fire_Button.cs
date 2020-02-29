using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fire_Button : MonoBehaviour
{
    public Button Fire,reload;
    public static bool check,reloadcheck,firecheck,shotgun;
    Vector3 previouspos = new Vector3(0,0,0);
    public Rigidbody bullet;
    public static int count;
    

    Vector3 rotation;
    void Start()
    {
        shotgun = false;
        check = true;
        reloadcheck = true;
        count = 0;
    }
    void Update()
    {
        //Debug.Log(check+"check in fire button update");
        if (check == true)
        {
            Fire.interactable = true;
            //reload.interactable = true;
        }
        else
        {
            Fire.interactable = false;
            reload.interactable = false;
        }

        if (reloadcheck == true && count==30 && firecheck==true)
        {
            reload.interactable = false;
        }
        else
        {
            reload.interactable = true;
        }
        
    }

    public void fire()
    {
        if (count == 0)
        {

            Muzzletest.autoreload = true;
            check = false;
            // reload.interactable = false;
            //Debug.Log(check + "check in fire button");
        }
        else
        {
            Muzzletest.fired = true;

            var temp = Camera.main.transform.position;
            var displace = Camera.main.transform.position - previouspos;
            if(!shotgun){
            Rigidbody bulletFired = Instantiate(bullet, Camera.main.ViewportToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0)), Camera.main.transform.rotation) as Rigidbody;
            bulletFired.velocity = bulletFired.transform.forward * 10;
            }
            else
            {
                for(int i = 0;i<3;i++){
                    Rigidbody bulletFired = Instantiate(bullet, Camera.main.ViewportToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0)), Camera.main.transform.rotation) as Rigidbody;
                    bulletFired.velocity = bulletFired.transform.forward * 10;
                }
            }

            //count--;
        }
    }
    
}
