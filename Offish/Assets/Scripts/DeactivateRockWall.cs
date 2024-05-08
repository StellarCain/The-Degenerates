using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateRockWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Barrel"))
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform t = transform.GetChild(i);
                t.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }
    }
}
