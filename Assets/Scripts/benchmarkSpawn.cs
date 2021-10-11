using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class benchmarkSpawn : MonoBehaviour
{
    public GameObject spawnPrefab;
    public float spawnDelay = 0f;
    private float currentDelay = 0f;
    // Start is called before the first frame update
    void Start()
    {
        currentDelay = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0) return;
        currentDelay -= Time.deltaTime;
        if (currentDelay > 0f) return;
        GameObject newSpawn = Instantiate(spawnPrefab);
        newSpawn.transform.SetParent(transform);
        newSpawn.transform.localPosition = Vector3.zero;
        currentDelay = spawnDelay;
    }
}
