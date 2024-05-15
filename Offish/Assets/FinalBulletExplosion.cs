using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBulletExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<ParticleSystem>().Emit(Random.Range(30, 35));
        StartCoroutine(Kill());
    }

    private IEnumerator Kill()
    {
        yield return new WaitForSeconds(1.5f);
    }
}
