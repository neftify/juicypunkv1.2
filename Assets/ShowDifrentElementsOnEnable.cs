using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InfiniteRunnerEngine;

public class ShowDifrentElementsOnEnable : MonoBehaviour
{
    public List<GameObject> variants = new List<GameObject>();
    static ExtraGameLogic extraGameLogic;

    [SerializeField()] GameObject explosive;
    [SerializeField()] GameObject jucie;
    int juicerate;
    int i;
    private void Start()
    {
        i = Random.Range(0, maxExclusive: variants.Count) % variants.Count;
    }
    void OnEnable()
    {
        if (extraGameLogic == null)
            extraGameLogic = FindObjectOfType<ExtraGameLogic>();

        foreach (var variant in variants)
        {
            
            if (variant != null) variant.SetActive(false);
        }
        if (variants.Count > 0)
        {
            /*i++;
            i %= variants.Count;*/
            i = Random.Range(0, maxExclusive: variants.Count) % variants.Count;
            if (variants[i] != null) {
                if (juicerate > 10)
                {
                    jucie.SetActive(true);
                    juicerate = 0;
                    return;
                }
                if (variants[i] == explosive && LevelManager.Instance.RunningTime < extraGameLogic.bombGraceTime)
                {
                   if (juicerate > 5)
                        jucie.SetActive(true);

                }
                else
                {
                    variants[i].SetActive(true);
                    if (variants[i] != jucie)
                    {
                        juicerate++;
                    }

                }
            }
        }
    }
    
}
