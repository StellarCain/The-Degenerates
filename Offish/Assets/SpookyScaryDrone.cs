using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the thing tht follows the player around through the aqueduct
public class SpookyScaryDrone : MonoBehaviour
{
    public Transform player;
    public Quaternion originalRotation;
    private float damageTimer = 0;

    private void Start()
    {
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        transform.position = 
            Vector3.Lerp(transform.position, 
            new Vector3(player.position.x + 30, transform.position.y, 
            transform.position.z), 3f * Time.deltaTime);
        */
        // casting a ray towards the player
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(player.position.x, player.position.y, transform.position.z), -Vector3.forward, out hit, 1000))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Vector3 direction = player.position - transform.position;
                Quaternion lookRotaton = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotaton, 10f * Time.deltaTime);
                //damageTimer += Time.deltaTime;
            }
            else
            {
                damageTimer = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, 10f * Time.deltaTime);               
            }

            if (damageTimer > 1f)
            {
                player.GetComponent<FishHealth>().Kill();
            }
        }
    }
}
