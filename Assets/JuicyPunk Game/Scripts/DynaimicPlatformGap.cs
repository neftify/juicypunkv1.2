using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InfiniteRunnerEngine;
[RequireComponent(typeof(DistanceSpawner))]
public class DynaimicPlatformGap : MonoBehaviour
{
    public LevelManager levelManager;
    DistanceSpawner DistanceSpawner;
    [SerializeField()] float minVariation ,maxVariation;
    [SerializeField()] float refreshVariationInterval = 5;
    float min, max;
    // Start is called before the first frame update
    void Start()
    {
        DistanceSpawner = GetComponent<DistanceSpawner>();
    }

    float timeLastRand;
    void RefreshVariation()
    {
        min = Random.Range(minVariation, maxVariation);
        max = Random.Range(minVariation, maxVariation);
        timeLastRand = Time.timeSinceLevelLoad;
    }
    void Update()
    {
        if (Time.timeSinceLevelLoad - timeLastRand >= refreshVariationInterval)
        {
            RefreshVariation();
        }
        float fixedDistance = levelManager.Speed / 2;
        DistanceSpawner.MinimumGap.x = fixedDistance + min;
        DistanceSpawner.MaximumGap.x = fixedDistance + max;
    }
}
