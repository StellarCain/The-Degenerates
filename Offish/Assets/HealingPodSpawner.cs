using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPodSpawner : MonoBehaviour
{
    public GameObject healingPod;

    private void Start()
    {
        StartCoroutine(SpawnHealingPod());
    }

    public void DestroyedHealingPod()
    {
        StartCoroutine(SpawnHealingPod());
    }

    private IEnumerator SpawnHealingPod()
    {
        yield return new WaitForSeconds(10f);
        Vector3 spawnPosition = new Vector3(
            transform.position.x + Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2),
            transform.position.y + Random.Range(-transform.localScale.y / 2, transform.localScale.y / 2),
            transform.position.z);
        Instantiate(healingPod, spawnPosition, Quaternion.identity, transform);
    }

    
}
