using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    public GameObject explosionFX;

    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.CompareTag("Enemy"))
        {
            DiverHealth diverHealth;
            if (collider.transform.TryGetComponent(out diverHealth))
            {
                diverHealth.Damage(10f);
                Instantiate(explosionFX, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
