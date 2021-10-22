using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGeneric : MonoBehaviour
{
    public GameController mainGC;

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        GameObject decal = Instantiate(mainGC.gcResources.BulletHoles[0], contact.point, Quaternion.LookRotation(contact.normal));
        decal.GetComponent<AudioSource>().Play();
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
