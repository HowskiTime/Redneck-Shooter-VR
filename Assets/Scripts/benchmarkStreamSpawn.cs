using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class benchmarkStreamSpawn : MonoBehaviour
{
    public float spawnDelay = 0f;
    private float currentDelay = 0f;

    public AssetBundle loadedAsset = null;

    // Start is called before the first frame update
    void Start()
    {
        currentDelay = spawnDelay;
        BetterStreamingAssets.Initialize();
        var getAsset = BetterStreamingAssets.LoadAssetBundleAsync("somefile/anyfrigginfile");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0 || !loadedAsset) return;
        currentDelay -= Time.deltaTime;
        if (currentDelay > 0f) return;

    }
}
