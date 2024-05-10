using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBox : MonoBehaviour
{
    private RestartManager restartManager;

    // Start is called before the first frame update
    void Start()
    {
        restartManager = FindObjectOfType<RestartManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            restartManager.ChangeRespawn();
            this.enabled = false;
        }
    }
}
