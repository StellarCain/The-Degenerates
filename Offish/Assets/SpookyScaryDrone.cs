using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the thing tht follows the player around through the aqueduct
public class SpookyScaryDrone : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.position = 
            Vector3.Lerp(transform.position, 
            new Vector3(player.position.x + 30, transform.position.y, 
            transform.position.z), .2f);
    }
}
