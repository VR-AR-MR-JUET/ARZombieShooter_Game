using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    public GameObject blood;
    private GameObject bloodloss;
    void Start()
    {
        
    }
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            Destroy(gameObject, 2);
          //  blood.SetActive(false);
        }
        Destroy(bloodloss, 1f);
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log(collision.gameObject.name + "destroyer");
        if(collision.gameObject.name =="Zombie1 1(Clone)")
        {
            bloodloss = Instantiate(blood, transform.position, transform.rotation) as GameObject;
            blood.transform.position = gameObject.transform.position;
           // blood.SetActive(true);
            Destroy(gameObject);
        }
    }
}
