using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilSquid : MonoBehaviour
{
    public Transform player;
    private Rigidbody rb;

    private bool readyToMove = true;

    private void Start()
    {
        StartCoroutine(Move());
        rb = transform.GetComponent<Rigidbody>();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2f, 4f));
            readyToMove = true;
        }
    }

    private void Update()
    {
        if (readyToMove)
        {
            readyToMove = false;
            transform.rotation = Quaternion.LookRotation(player.position - transform.position);
            rb.AddForce(transform.forward * 200f, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<FishHealth>().Damage(5);
        }
    }
}
