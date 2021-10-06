using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetFractureMonkey : MonoBehaviour
{
    public GameObject WholeGO;
    public GameObject FracturedGO;

    private void OnTriggerEnter(Collider other)
    {
        WholeGO.SetActive(false);
        FracturedGO.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
