using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GunManager : MonoBehaviour
{
    public GameObject Revolver,Assault,Shotgun;
    public GameObject panel,menubutton,closebutton;
    private Animator animator;
    private bool decrement;
    // Start is called before the first frame update
    void Start()
    {
        decrement = false;
        Assault.SetActive(true);
        Revolver.SetActive(false);
        Shotgun.SetActive(false);
        animator = panel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

       
    }
        
    public void OpenMenu()
    {
      
            menubutton.SetActive(false);
            closebutton.SetActive(true);
            animator.SetBool("drop", true);
       
    }
    public void CLoseMenu()
    {
            closebutton.SetActive(false);
            menubutton.SetActive(true);
            animator.SetBool("drop", false);
       
    }
    public void selectassault()
    {
        if(decrement == true)
        {
            Difficulty.count = Difficulty.count + 2;
        }
        Shotgun.SetActive(false);
        Assault.SetActive(true);
    }
    public void selectshotgun()
    {
        Fire_Button.shotgun = true;
        Difficulty.count = Difficulty.count - 2;
        decrement = true;
        Shotgun.SetActive(true);
        Assault.SetActive(false);
    }
}
