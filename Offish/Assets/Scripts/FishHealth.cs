using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishHealth : MonoBehaviour
{
    private float health = 100;
    public bool losingHealth = false;
    public float maxSpeedInDecay = 20;
    public ParticleSystem decayParticleSystem;
    public bool isHiding = false;

    private float maxSpeed = 0;

    private void Start()
    {
        maxSpeed = transform.GetComponent<MoveFish>().maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        var emission = decayParticleSystem.emission;

        if (losingHealth)
        {
            transform.GetComponent<MoveFish>().maxSpeed =
                Mathf.Lerp(transform.GetComponent<MoveFish>().maxSpeed, maxSpeedInDecay, 5 * Time.deltaTime);
            emission.enabled = true;
        }
        else
        {
            transform.GetComponent<MoveFish>().maxSpeed =
                Mathf.Lerp(transform.GetComponent<MoveFish>().maxSpeed, maxSpeed, 5 * Time.deltaTime);
            emission.enabled = false;
        }
    }
}
