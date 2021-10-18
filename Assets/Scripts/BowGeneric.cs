using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowGeneric : MonoBehaviour
{
    public Transform stringTop;
    public Transform stringBottom;
    public Transform stringGrab;

    public LineRenderer myLine;
    public bool beingHeld = false;
    public bool stringHeld = false;

    // Start is called before the first frame update
    void Start()
    {
        myLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {  
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        myLine.SetPosition(0, stringTop.position);
        myLine.SetPosition(1, stringGrab.position);
        myLine.SetPosition(2, stringBottom.position);
        if (stringHeld) return;
        //transform.position.x = josh.position.x + (mark.position.x - josh.position.x) / 2;
        stringGrab.position = Vector3.MoveTowards(stringGrab.position,(stringBottom.position-stringTop.position)*.5f,Time.deltaTime);
    }
}

