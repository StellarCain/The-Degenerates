using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCamera : MonoBehaviour
{
    public Transform fish;
    public float smoothSpeed = 5f;
    public float rotationSpeed = 4f;
    public float zMagnitude = 1f;
    private float zOriginal;

    public Transform pos1;
    public Transform pos2;

    private void Start()
    {
        zOriginal = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        MoveFish fishScript = fish.GetComponent<MoveFish>();
        // Adding the normalized speed to the z axis of the camera (to acheive a speed effect)
        float zPos = zOriginal - fishScript.GetSpeed() / fishScript.maxSpeed * zMagnitude;
        Vector3 targetPosition = new Vector3(fish.position.x + 20, fish.position.y + 10, zPos);
        // Interpolating the camera
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        //Making sure its always looking at the fish
        Vector3 direction = fish.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
    }
}
