using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineSpotlight : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float detectionRange = 300f;

    // Update is called once per frame
    void Update()
    {
        /*
        if (Vector3.Distance(player.transform.position, transform.position) < detectionRange)
        {
            Vector3 direction = player.position - transform.position;
            Quaternion lookRotaton = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotaton, speed * Time.deltaTime);

            player.GetComponent<FishHealth>().losingHealth = true;
            transform.parent.parent.GetComponent<SubmarineController>().speed = 0;
        }
        else
        {
            player.GetComponent<FishHealth>().losingHealth = false;
            transform.parent.parent.GetComponent<SubmarineController>().speed = .1f;
        }
        */
    }
}
