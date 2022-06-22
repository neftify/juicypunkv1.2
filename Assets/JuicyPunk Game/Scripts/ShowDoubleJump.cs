using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InfiniteRunnerEngine;
public class ShowDoubleJump : MonoBehaviour
{
    [SerializeField()] Jumper jumper;
    public GameObject higlight;
    // Start is called before the first frame update
    void Start()
    {
        jumper = GetComponent<Jumper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumper._numberOfJumpsLeft == 0)
        {
            higlight.SetActive(true);
        }
        else
        {
            higlight.SetActive(false);
        }
    }
}
