using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideFish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.GetComponent<FishHealth>().isHiding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.GetComponent<FishHealth>().isHiding = false;
        }
    }
}
