using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseCave : MonoBehaviour
{
    public Transform rockWall;
    private bool started = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
            started = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
            rockWall.position = Vector3.Lerp(rockWall.position, transform.position, 5 * Time.deltaTime);
    }
}
