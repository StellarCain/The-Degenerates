using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPod : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.GetComponent<HealingPodSpawner>().DestroyedHealingPod();
            other.transform.GetComponent<FishHealth>().Heal();
            Destroy(gameObject);
        }
    }
}
