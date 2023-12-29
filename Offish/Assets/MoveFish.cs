using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFish : MonoBehaviour
{
    //speed at which we are to be traveling
    public float maxSpeed = 5f;
    public float acceleration = .1f;

    //place where we are to be going
    private Vector3 plc;
    private Rigidbody rb;

    private float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //we start where we are
        plc = transform.position;
        rb = transform.GetComponent<Rigidbody>();
    }

    public float GetSpeed()
    {
        return speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseClickPosition = Input.mousePosition;
            mouseClickPosition.z = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);

            plc = Camera.main.ScreenToWorldPoint(mouseClickPosition);
            plc.z = transform.position.z;

            print("pos: " + plc);

            Vector3 direction = plc - transform.position;
            Quaternion rot = Quaternion.LookRotation(direction);
            transform.rotation = rot;

            speed += acceleration;
        }
        else
        {
            speed -= acceleration;
        }

        speed = Mathf.Clamp(speed, 0, maxSpeed);

        // we ball
        rb.velocity = transform.forward * speed;
    }
}