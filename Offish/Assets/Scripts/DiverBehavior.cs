using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverBehavior : MonoBehaviour
{
    public float speed = 50f;
    public float dashDistance = 20f;
    public int damage = 5;
    public bool isAnimatedDiver = false;
    private Transform target;
    private Rigidbody rb;
    private bool isDashing = false;
    private bool chargingDash = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < 200f)
        {
            // Normal follow behavior
            if (!isDashing)
            {
                Vector3 direction = target.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = lookRotation;

                if (!chargingDash && Vector3.Distance(transform.position, target.position) < dashDistance)
                {
                    chargingDash = true;
                    rb.velocity = Vector3.zero;
                    StartCoroutine(Dash());
                }
            }

            if (!chargingDash)
                rb.velocity = transform.forward * speed;
        }
    }

    private IEnumerator Dash()
    {
        chargingDash = true;
        yield return new WaitForSeconds(1f);
        isDashing = true;
        rb.AddForce(transform.forward * 100f, ForceMode.Impulse);
        yield return new WaitForSeconds(2f);
        isDashing = false;
        chargingDash = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && isDashing)
        {
            collision.collider.GetComponent<FishHealth>().Damage(damage);

            if (isAnimatedDiver)
            {
                FindObjectOfType<Scene1To2>().ExecuteScene1End();
            }
        }
    }
}
