using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpwaner : MonoBehaviour
{
    public GameObject zombieprefab;
    private GameObject zombies;
    //private int count = 0;
    private bool spawn = true;
    private Objectspawn objectspwan;
    void Start()
    {
        objectspwan = FindObjectOfType<Objectspawn>();
    }
    void Update()
    {
        if (spawn == true)
        {
            Spawn();
        }
       /* if (GameObject.Find("Zombie1 1(Clone)") != null)
        {
            {
                Destroy(GameObject.Find("Zombie1 1(Clone)"), 3f);
            }
        }*/

    }

    private void Spawn()
    {
            StartCoroutine(HandleIt());
        zombies = Instantiate(zombieprefab, objectspwan.transform.position, objectspwan.transform.rotation) ;
        zombies.SetActive(true);
            spawn = false;
    }

    IEnumerator HandleIt()
    {
       // Debug.Log("Time" + Time.time);
        yield return new WaitForSeconds(4);
        spawn = true;
       // Debug.Log("Time1" + Time.time);
    }
}
