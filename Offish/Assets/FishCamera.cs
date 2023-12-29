using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCamera : MonoBehaviour
{
    public Transform fish;
    public float smoothSpeed = 5f;
    public float zMagnitude = 1f;
    private float zOriginal;

    private void Start()
    {
        zOriginal = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        MoveFish fishScript = fish.GetComponent<MoveFish>();
        // Adding the normalized speed to the z axis of the camera (to acheive a like speed effect)
        float zPos = zOriginal - fishScript.GetSpeed() / fishScript.maxSpeed * zMagnitude;
        Vector3 targetPosition = new Vector3(fish.position.x, fish.position.y, zPos);
        // Interpolating the camera
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
