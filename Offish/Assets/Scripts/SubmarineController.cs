using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineController : MonoBehaviour
{
    public Transform player;
    public float speed = .1f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed;
    }
}
