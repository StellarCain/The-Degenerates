using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SharkBehavior : MonoBehaviour
{
    public float speed;
    public bool chaseShark = false;
    private Transform target;
    private float hidingTimer;
    private Rigidbody rb;
    private bool returning = false;

    // Start is called before the first frame update
    void Start()
    {
        target = UnityEngine.GameObject.FindWithTag("Player").transform;
        rb = transform.GetComponent<Rigidbody>();
        //StartCoroutine(StartBehavior());
    }

    private void FixedUpdate()
    {
        if (!returning)
        {
            if (target.GetComponent<FishHealth>().isHiding)
                hidingTimer += Time.deltaTime;

            Vector3 direction = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = lookRotation;

            Vector3 targetVelocity = Vector3.zero;

            if (!target.GetComponent<FishHealth>().isHiding) // Last constant is the distance at which the shark will keep following the player if they hide
            {
                targetVelocity = transform.forward * speed;
                hidingTimer = 0;
            }
            else if (target.GetComponent<FishHealth>().isHiding && Vector3.Distance(transform.position, target.position) > 50) // Stopping range
            {
                targetVelocity = transform.forward * speed;
            }
            else if (target.GetComponent<FishHealth>().isHiding && Vector3.Distance(transform.position, target.position) < 51) // Turning back range
            {
                targetVelocity = Vector3.zero;
            }

            if (hidingTimer > 2 && !chaseShark)
            {
                returning = true;
                StartCoroutine(EndBehavior());
            }

            // Interpolating the shark speed to match the target velocity
            rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, 3 * Time.fixedDeltaTime);
        }
    }

    private IEnumerator EndBehavior()
    {
        // THE SHARK GOES BACK TO WHERE IT CAME FROM
        Vector3 direction = transform.parent.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = lookRotation;

        transform.GetComponent<AudioSource>().Play();
        StartCoroutine(transform.parent.GetComponent<SharkSpawner>().DestroySelf());

        for (float i = 0; i <= 1; i += (1f / 1500f))
        {
            yield return new WaitForEndOfFrame();
            transform.position += transform.forward / 2f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && !collision.transform.GetComponent<FishHealth>().isHiding)
        {
            collision.transform.GetComponent<FishHealth>().Kill();
        }
    }
}
