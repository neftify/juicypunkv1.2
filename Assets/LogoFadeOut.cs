using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.InfiniteRunnerEngine;
public class LogoFadeOut : MonoBehaviour
{
    [SerializeField]
    public Image logo;
    [SerializeField]
    public GameManager gm;
    public float lifeTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float a = 1;
    // Update is called once per frame
    void Update()
    {
       if ( gm.Status == GameManager.GameStatus.GameInProgress )
        {
            a -= Time.deltaTime  * (1/ lifeTime);
            logo.color = new Color(logo.color.r, logo.color.g, logo.color.b,a);
        }
    }
}
