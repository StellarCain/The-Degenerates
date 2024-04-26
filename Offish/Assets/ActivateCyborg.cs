using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCyborg : MonoBehaviour
{
    public List<GameObject> spotlights;
    public Transform cyborg;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject go in spotlights)
            {
                go.GetComponent<SpookyScaryDrone>().enabled = false;
            }

            cyborg.GetComponent<Cyborg>().enabled = true;
        }
    }
}
