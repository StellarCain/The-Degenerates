using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishBullet : MonoBehaviour
{
    public float life = 15;

    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.CompareTag("Player"))
        {
            collider.transform.GetComponent<FishHealth>().Damage(5);
            Destroy(gameObject);
        }
    }
}
