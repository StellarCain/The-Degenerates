using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilSquid : MonoBehaviour
{
    public Transform player;
    private Rigidbody rb;

    private void Start()
    {
        StartCoroutine(Move());
        rb = transform.GetComponent<Rigidbody>();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            transform.rotation = Quaternion.LookRotation(player.position - transform.position);
            rb.AddForce(transform.forward * 200f, ForceMode.Impulse);
        }
    }
}
