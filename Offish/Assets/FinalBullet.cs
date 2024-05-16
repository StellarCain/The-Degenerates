using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBullet : MonoBehaviour
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
            SquidHealth possibleSquidHealth;
            if (collider.transform.TryGetComponent(out possibleSquidHealth))
            {
                possibleSquidHealth.Damage(20);
            }
            JellyfishHealth possibleJellyfishHealth;
            if (collider.transform.TryGetComponent(out possibleJellyfishHealth))
            {
                possibleJellyfishHealth.Damage(10);
            }

            Instantiate(explosionFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
