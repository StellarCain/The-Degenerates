using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFish : MonoBehaviour
{
    //speed at which we are to be traveling
    public float maxSpeed = 5f;
    public float acceleration = .1f;
    public float velocityLerpSpeed = 3f;
    public float decceleration = .05f;
    public float mouseLerpSpeed = 5f;
    public ParticleSystem sandDisplacementParticleSystem;

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

    private void Update()
    {
        Vector3 mouseClickPosition = Input.mousePosition;
        mouseClickPosition.z = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseClickPosition);
        mouseWorldPosition.z = transform.position.z;

        // Lerping the position of the mouse for an interesting smooth movement
        plc = Vector3.Lerp(plc, mouseWorldPosition, mouseLerpSpeed * Time.deltaTime);

        RaycastHit hitInfo;
        // Casting a ray down from the fish's position to hit the sand floor and put the particle system there
        if (Physics.Raycast(transform.position + transform.forward, Vector3.down, out hitInfo, 500))
        {
            sandDisplacementParticleSystem.transform.position = hitInfo.point;
            sandDisplacementParticleSystem.transform.forward = hitInfo.normal;

            var emission = sandDisplacementParticleSystem.emission;

            if (Vector3.Distance(hitInfo.point, transform.position) > 10f)
            {
                emission.rateOverDistance = 0;
            }
            else
            {
                emission.rateOverDistance = speed / maxSpeed;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && Vector3.Distance(transform.position, plc) > 2f)
        {
            Vector3 direction = plc - transform.position;
            Quaternion rot = Quaternion.LookRotation(direction);
            transform.rotation = rot;

            speed += acceleration;
        }
        else
        {
            speed -= decceleration;
        }

        speed = Mathf.Clamp(speed, 0, maxSpeed);

        // we ball
        rb.velocity = Vector3.Lerp(rb.velocity, transform.forward * speed, velocityLerpSpeed * Time.deltaTime);
    }
}