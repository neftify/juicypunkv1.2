using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InfiniteRunnerEngine; 
public class DamageBehaviour : MonoBehaviour
{
    [SerializeField()]
    PlayableCharacter player;
    private void Start()
    {
        player = GetComponent<PlayableCharacter>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Damage"))
        {
            other.gameObject.SetActive(false);
           //player.Die();
            LevelManager.Instance.KillCharacter(player);
        }
    }
}
