using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombieground : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        var temp =transform.position;;
        temp.y=0f;
        transform.position = temp;
    }
}
