using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class benchmarkFPS : MonoBehaviour
{
    public TextMeshPro fpsHud;
    public int worstFps = 72;

    public int currentFps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentFps = (int)(1f / Time.deltaTime);
        if (Time.frameCount % 50 == 0)
            fpsHud.text = currentFps.ToString() + "/" + worstFps.ToString() + " FPS";
    }
}
