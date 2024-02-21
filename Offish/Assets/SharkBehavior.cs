using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkBehavior : MonoBehaviour
{
    public float speed;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = lookRotation;

        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
