using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Muzzletest : MonoBehaviour
{

    private Animator anim;
    public static bool reload, cancel, check;
    public Text text;
    public int ammo, prevassaultrifleammo, prevshotgunammo;
    public static int maxammo;
    public static bool autoreload, fired;
    private GameObject flash;
    public new AudioSource audio;
    public AudioClip[] aclip;
    void Start()
    {
        
        check = false;
        prevassaultrifleammo = 20;
        prevshotgunammo = 6;
        flash = GameObject.Find("Muzzle Flash");
        if (flash.activeInHierarchy)
        {
            flash.SetActive(false);
        }
        if (gameObject.name == "Assault Rifle")
        {
            audio.clip = aclip[0];
            Difficulty.count = 2;
            Fire_Button.count = 20;
            maxammo = 20;
            ammo = 20;
            prevassaultrifleammo = ammo;
        }
        if (gameObject.name == "Shotgun")
        {
            // audio.clip = aclip[];
            Difficulty.count = 0;
            Fire_Button.count = 6;
            maxammo = 6;
            ammo = 6;
            prevassaultrifleammo = ammo;
        }

        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Reload();
        ammo = Fire_Button.count;


        if (gameObject.name == "Assault Rifle")
        {
            text.text = "Ammo : " + ammo.ToString();
        }
        if (autoreload == true || reload == true)
        {
            Fire_Button.check = false;
            autoReload();


        }
        text.text = "Ammo : " + ammo.ToString();
        if (fired == true)
        {
            turnOnMuzzleFlash();
            fired = false;
        }
    }

    public void ReloadEnd()
    {
        Fire_Button.check = true;
        Fire_Button.reloadcheck = false;
        ammo = maxammo;
        text.text = "Ammo : " + ammo.ToString();
        Fire_Button.count = maxammo;
        if (gameObject.name == "Assault Rifle")
        {
            prevassaultrifleammo = 20;

        }
        if (gameObject.name == "Shotgun")
        {
            prevshotgunammo = 6;
        }
    }
    public void shotgunreloadaudio()
    {
        {
            audio.clip = aclip[1];
            audio.Play();

        }
    }
    public void assaultriflereload()
    {
        audio.clip = aclip[1];
        audio.Play();
    }
    public void ReloadStart()
    {

        Fire_Button.check = false;
        Fire_Button.reloadcheck = true;
        ammo = maxammo;
        text.text = "Ammo : " + ammo.ToString();
        Fire_Button.count = ammo;
    }


    public void autoReload()
    {

        anim.SetTrigger("reload");

        autoreload = false;
        reload = false;
        //check = false;
        }
        public void Reload()
        {
            if (ammo < maxammo && check==true)
            {
                reload = true;
                Fire_Button.check = false;
            check = false;
            }

        }
        public void turnOnMuzzleFlash()
        {
            anim.SetTrigger("fire");
        }

        public void firestart()
        {
            Handheld.Vibrate();
            flash.SetActive(true);
            Fire_Button.check = false;
            Fire_Button.firecheck = true;
            if (gameObject.name == "Assault Rifle")
            {
            audio.clip = aclip[0];
                audio.Play();

            }
        }
        public void shotgunfire()
        {
            audio.clip = aclip[0];
            audio.Play();
        }
        public void PlaySound()
        {
            audio.clip = aclip[1];
            audio.Play();
        }
        public void fireend()
        {
            flash.SetActive(false);
            Fire_Button.check = true;
            Fire_Button.firecheck = false;
            if (gameObject.name == "Assault Rifle")
            {
                prevassaultrifleammo = prevassaultrifleammo - 1;
                Fire_Button.count = prevassaultrifleammo;
                ammo = Fire_Button.count;
                text.text = "Ammo : " + ammo.ToString();

            }
            if (gameObject.name == "Shotgun")
            {
                prevshotgunammo = prevshotgunammo - 1;
                Fire_Button.count = prevshotgunammo;
                ammo = Fire_Button.count;
                text.text = "Ammo : " + ammo.ToString();
            }
        }
    }

