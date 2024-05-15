using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSword : MonoBehaviour
{
    public Transform sword;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("slice");
            Collider[] colliders = Physics.OverlapSphere(transform.position + transform.forward * 20f, 7f);

            foreach (Collider c in colliders)
            {
                if (c.CompareTag("Enemy"))
                {
                    print(c.name);
                }
            }

            sword.Rotate(Vector3.up, 50f);
        }
    }
}
