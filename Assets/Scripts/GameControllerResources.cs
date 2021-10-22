using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerResources : MonoBehaviour
{
    public GameController mainGC;

    public GameObject[] BulletHoles;

    // Start is called before the first frame update
    void Start()
    {
        mainGC = GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
