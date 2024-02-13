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
    public ParticleSystem startAbilityParticleSystem;
    public List<string> companions = new List<string>();

    //place where we are to be going
    private Vector3 plc;
    private Rigidbody rb;

    // Abilities
    private int currentCompanion = 0;
    private bool usingAbility = false;
    private float speed = 0f;
    private FishCamera fishCamera;

    // Start is called before the first frame update
    void Start()
    {
        //we start where we are
        plc = transform.position;
        rb = transform.GetComponent<Rigidbody>();
        fishCamera = Camera.main.GetComponent<FishCamera>();
    }

    public float GetSpeed()
    {
        return speed;
    }

    private Quaternion FaceTowards(Vector3 target)
    {
        Vector3 direction = target - transform.position;
        Quaternion rot = Quaternion.LookRotation(direction);
        return rot;
    }

    private void Update()
    {
        Vector3 mouseClickPosition = Input.mousePosition;
        mouseClickPosition.z = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseClickPosition);
        mouseWorldPosition.z = transform.position.z;

        // Lerping the position of the mouse for an interesting smooth movement
        plc = Vector3.Lerp(plc, mouseWorldPosition, mouseLerpSpeed * Time.deltaTime);

        // PARTICLE SYSTEM STUFF
        RaycastHit hitInfo;
        // Casting a ray down from the fish's position to hit the sand floor and put the particle system there
        if (Physics.Raycast(transform.position + transform.forward, Vector3.down, out hitInfo, 500))
        {
            if (hitInfo.collider.CompareTag("Seabed"))
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

        if (Input.GetKeyDown(KeyCode.E) && !usingAbility)
        {
            UseAbility(companions[currentCompanion]);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (usingAbility) return;
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButton(0) && Vector3.Distance(transform.position, plc) > 2f)
        {
            transform.rotation = FaceTowards(plc);

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

    private void UseAbility(string ability)
    {
        startAbilityParticleSystem.Emit(35);
        // Burying
        if (ability == "Flounder")
        {
            StartCoroutine(UseFlounder());
        }
    }

    // FLOUNDER ABILITY SLAAY
    private IEnumerator UseFlounder()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, Vector3.down + Vector3.right, out hitInfo, 20))
        {
            usingAbility = true;
            rb.velocity = Vector3.zero;

            rb.isKinematic = true;
            Vector3 targetPosition = hitInfo.point - Vector3.up * 5f;

            transform.rotation = FaceTowards(targetPosition);
            yield return new WaitForSeconds(1f);

            fishCamera.ChangeCameraMode("flounder");
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                yield return new WaitForEndOfFrame();
                transform.position = Vector3.Lerp(transform.position, targetPosition, i);
            }
        }
    }
}