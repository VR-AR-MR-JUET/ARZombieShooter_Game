using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class Movement : MonoBehaviour
{
    private ARRaycastManager aRRaycastManager;
    private float enemySpeed = 10f;
    //public Image image;
    public static int count;
    private  Animator animator;
    private new Rigidbody rigidbody;
    //public GameObject stop;
    private int counter = 0;
    //private int speed = 7;
    //public GameObject firePoint;
    private new CapsuleCollider collider;
    public bool dead = false;
    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        count = 0;
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider>();
        collider.enabled = true;
       // Debug.Log("working");
    }

    void FixedUpdate()
    {
        {
            var lookPos = Camera.main.transform.position - transform.position;
            //transform.position.y = 0;
            var camerapos = Camera.main.transform.position;
            camerapos.y = 0;
            var temp = transform.position;
            temp.y = 0;
            float distance = Vector3.Distance(camerapos, temp);
            camerapos.y = 0;
            
            // temp.y = 0;
            //transform.position = temp;
            lookPos.y = 0;
            var stopped = lookPos;
            //Debug.Log(lookPos.x + "," + lookPos.y + "," + lookPos.z);
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, enemySpeed * Time.deltaTime);
            //  var stoppedmagnitude = distance - 2f;
            //     stoppedmagnitude = Mathf.Abs(stoppedmagnitude);
            if (distance <= 1.5f)
            {
                animator.SetBool("attack", true);
            }
            else
            {
                animator.SetBool("attack", false);
                if (distance >= 3.2f)
                {
                    animator.ResetTrigger("walk");
                    animator.SetTrigger("run");
                }
                else
                {
                    animator.ResetTrigger("run");
                    animator.SetTrigger("walk");
                }

                //Debug.Log(transform.position.x + "," + transform.position.y + "," + transform.position.z + "Enemy");
                var move = temp + lookPos * 0.1f * Time.deltaTime;
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                aRRaycastManager.Raycast(Camera.main.WorldToScreenPoint(temp), hits, TrackableType.Planes);
                 if (hits.Count > 0)
                {
                    temp.y = 0f;
                    rigidbody.MovePosition(temp + lookPos * 0.1f * Time.deltaTime);
                }
               // rigidbody.MovePosition(temp + lookPos * 0.1f * Time.deltaTime);
                //collider.SimpleMove(temp + lookPos * 0.1f * Time.deltaTime);
            }

            if (dead)
            {
                Destroy(gameObject,2.5f);
            }
        }

    }
   
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name + "zombie");
        if (collision.gameObject.name=="Bullet(Clone)")
        {
            Handheld.Vibrate();
            if (counter >= Difficulty.count)
            {
                Score.isDead = true;
                Debug.Log("killing");
                collider.enabled = false;
                dead = true;
                Debug.Log("Dead");
                animator.SetTrigger("death");
                //count++;
            }
            counter++;
           // dead = false;
        }
    }
}

  