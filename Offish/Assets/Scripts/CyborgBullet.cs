using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyborgBullet : MonoBehaviour
{
    public float life = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Lifetime());
    }

    private IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(life);
        UnityEngine.GameObject.Destroy(gameObject);
    }
}
