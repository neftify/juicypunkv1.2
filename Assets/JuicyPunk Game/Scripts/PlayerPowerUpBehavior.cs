using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpBehavior : MonoBehaviour
{
    /// <summary>
    /// todo 
    /// time out expire
    /// speed uplevel add to score
    /// </summary>
    [SerializeField] Animator animator;
    [SerializeField] LineRenderer line;
    public bool PoweredUp {
        get {
            return (_PoweredUp);
        }
        set {
            _PoweredUp = value;
            line.enabled = _PoweredUp;
            animator.SetBool("PoweredUp", _PoweredUp);
            foreach (var shadow in speedShadow)
            {
                shadow.gameObject.SetActive(_PoweredUp);
            }
        } 
    }
    private bool _PoweredUp;
    float speed = 0.033f;
    // Start is called before the first frame update
    void Start()
    {
        PoweredUp = false;
        StartCoroutine("LineUpdatePos");
    }
 \
    private void Update()
    {
    }
    public Transform[] speedShadow;
    public List<Vector3> pastPos = new List<Vector3>();
    IEnumerator LineUpdatePos()
    {
        for (int i = 0; i < speedShadow.Length; i++)
        {
            pastPos.Add(transform.position);
        }
        
        while (enabled) {
            pastPos.Add(transform.position);
            for (int i = 0; i < pastPos.Count; i++)
            {
                if (i >= speedShadow.Length) break;//i*i*0.25f
                speedShadow[i].position = new Vector3(pastPos[speedShadow.Length - i].x-(i*1*0.5f), pastPos[speedShadow.Length - i].y,0);
            }
            pastPos.RemoveAt(0);
            yield return new WaitForSeconds(speed);
        }
            
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Juice"))
        {
            PoweredUp = true;
            other.gameObject.SetActive(false);
        }
    }
}
