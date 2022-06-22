using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InfiniteRunnerEngine;
using MoreMountains.Tools;


public class PuffOfSmoke : MonoBehaviour
{
    [SerializeField()] Jumper jumper;
    [SerializeField()] MMSimpleObjectPooler pool;
    int jumpsPastframe;
    // Start is called before the first frame update
    void Start()
    {
        jumper = GetComponent<Jumper>();
        pool.transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        if (jumper._numberOfJumpsLeft != jumpsPastframe)
        {
         if (jumper._numberOfJumpsLeft != jumper.NumberOfJumpsAllowed)
            {
            var o = pool.GetPooledGameObject();
            o.SetActive(true);
            o.transform.position = transform.position;
            }
            jumpsPastframe = jumper._numberOfJumpsLeft;
        }
    }
}
