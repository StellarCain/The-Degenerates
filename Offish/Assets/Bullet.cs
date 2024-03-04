using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;

    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.CompareTag("Enemy"))
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
