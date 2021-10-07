using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetFractureMonkey : MonoBehaviour
{
    public GameObject WholeGO;
    public GameObject FracturedGO;

    public bool fractured = false;
    public float timeLeft = 10f;

    private void OnTriggerEnter(Collider other)
    {
        WholeGO.SetActive(false);
        FracturedGO.SetActive(true);
        fractured = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!fractured) return;
        timeLeft -= Time.deltaTime;
        if (timeLeft > 0f) return;
        Destroy(gameObject);
    }
}
