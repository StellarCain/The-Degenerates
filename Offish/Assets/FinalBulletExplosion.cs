using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBulletExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<ParticleSystem>().Emit(Random.Range(40, 55));
        Destroy(gameObject, 2f);
    }
}
