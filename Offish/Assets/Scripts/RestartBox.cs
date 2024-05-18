using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBox : MonoBehaviour
{
    public int respawnNumber = 0;
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
            restartManager.ChangeRespawn(respawnNumber);
            enabled = false;
        }
    }
}
