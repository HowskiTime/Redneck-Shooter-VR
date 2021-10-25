using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public float speed;
    Rigidbody rb;
    public bool chase;
    public bool stop;


    //public GameObject dog;

    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        
         
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        if(chase == true)
        {
        //anim.animation
        
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(pos);
        transform.LookAt(target);
        //anim.Play("metarig|Run_001");

        }
        else
        {
        speed = 0;
        
        }
        if(speed == 0)
        {
        
        }
        





    }
    private void OnTriggerEnter(Collider other)
    {
        chase = false;
        stop = true;
        anim.Play("Idle");
        //anim.Play("metarig|iDLE");
    }

    private void OnTriggerExit(Collider other)
    {
        anim.Play("Run");
        chase = true;
        stop = false;
        speed = 2;
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(pos);
        transform.LookAt(target);
        
    }
}
