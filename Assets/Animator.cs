using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Animator : MonoBehaviour
{
   
    Animator animator;
    //public GameObject dog;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }



    //private void OnTriggerEnter(Collider other)
    //{
    //    animator.GetBool("isChasing", true);
    //anim.Play("Run");

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //anim.Play("Idle");
    //}
}
