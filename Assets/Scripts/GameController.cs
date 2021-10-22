using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameControllerResources gcResources;

    // Start is called before the first frame update
    void Start()
    {
        gcResources = GetComponent<GameControllerResources>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
