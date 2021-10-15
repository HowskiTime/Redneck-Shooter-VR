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

    // Start is called before the first frame update
    void Start()
    {
        myLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {  
        //Debug.DrawRay(stringTop.position, stringBottom.position, Color.green);
        myLine.SetPosition(0, stringTop.position);
        myLine.SetPosition(1, stringGrab.position);
        myLine.SetPosition(2, stringBottom.position);
    }
}

