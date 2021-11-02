using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementHeadPosition : MonoBehaviour
{
    public Transform xrHeadPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + (xrHeadPosition.localPosition), 0.1f);
    }
}
