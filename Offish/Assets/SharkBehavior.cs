using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkBehavior : MonoBehaviour
{
    public float speed;
    private Transform target;
    private float hidingTimer;
    private Rigidbody rb;
    private bool returning = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rb = transform.GetComponent<Rigidbody>();
        //StartCoroutine(StartBehavior());
    }

    private void FixedUpdate()
    {
        if (!returning)
        {
            Vector3 targetVelocity = Vector3.zero;

            if (!target.GetComponent<FishHealth>().isHiding || (target.GetComponent<FishHealth>().isHiding && Vector3.Distance(transform.position, target.position) < 10)) // Last constant is the distance at which the shark will keep following the player if they hide
            {
                Vector3 direction = target.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = lookRotation;

                targetVelocity = transform.forward * speed;
                hidingTimer = 0;
            }
            else if (target.GetComponent<FishHealth>().isHiding && Vector3.Distance(transform.position, target.position) > 60) // Stopping range
            {
                targetVelocity = transform.forward * speed;
            }
            else if (target.GetComponent<FishHealth>().isHiding && Vector3.Distance(transform.position, target.position) < 61) // Turning back range
            {
                targetVelocity = Vector3.zero;
                hidingTimer += Time.deltaTime;
            }

            if (hidingTimer > 2)
            {
                returning = true;
                StartCoroutine(EndBehavior());
            }

            // Interpolating the shark speed to match the target velocity
            rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, 3 * Time.deltaTime);
        }
    }

    private IEnumerator EndBehavior()
    {
        // THE SHARK GOES BACK TO WHERE IT CAME FROM
        Vector3 direction = transform.parent.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = lookRotation;

        StartCoroutine(transform.parent.GetComponent<SharkSpawner>().DestroySelf());

        for (float i = 0; i <= 1; i += (1f / 1500f))
        {
            yield return new WaitForEndOfFrame();
            transform.position += transform.forward / 2f;
        }   
    }

}
