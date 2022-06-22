using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InfiniteRunnerEngine;
using MoreMountains.Tools;
public class ExtraGameLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per framev
    public GameManager gm;
    public LevelManager levelManager;

    MovingObject[] platforms;
    public DistanceSpawner DistanceSpawner;

    

    [SerializeField()]public float bombGraceTime = 5; //time until bombs are introduced
    
    void Update()
    {
      
        if (gm.Status == GameManager.GameStatus.GameOver)
        {
             platforms = FindObjectsOfType<MovingObject>();
             foreach (var platform in platforms)
             {
                 platform.enabled = false;
                if (platform.TryGetComponent(out MMPoolableObject pool)){
                    pool.enabled = false;
                }
             }
          
            DistanceSpawner.Spawning = false;
            LevelManager.Instance.SetSpeed(0.01f);
        }
    }
}
