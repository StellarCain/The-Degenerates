using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartManager : MonoBehaviour
{
    public Transform player;
    public List<Transform> respawns = new List<Transform>();
    private int currentRespawnIndex = 0;

    private void Awake()
    {
        currentRespawnIndex = RestartCounter.GetRespawnIndex();
    }

    private void Start()
    {
        Respawn();
    }

    public void ChangeRespawn()
    {
        currentRespawnIndex++;
        RestartCounter.SetRespawnIndex(currentRespawnIndex);
        print(currentRespawnIndex);
    }

    private void Respawn()
    {
        player.position = new Vector3(respawns[currentRespawnIndex].position.x, respawns[currentRespawnIndex].position.y, player.position.z);
    }
}
