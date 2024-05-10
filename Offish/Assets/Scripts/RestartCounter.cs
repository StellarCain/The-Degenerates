using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RestartCounter
{
    private static int respawnIndex = 0;

    public static int GetRespawnIndex()
    {
        return respawnIndex;
    }

    public static void SetRespawnIndex(int index)
    {
        respawnIndex = index;
    }
}
