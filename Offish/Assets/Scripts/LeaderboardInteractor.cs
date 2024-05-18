using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LeaderboardInteractor
{
    private static float time;

    public static void StartTime()
    {
        time = Time.realtimeSinceStartup;
    }

    public static float GetTime()
    {
        return Time.realtimeSinceStartup - time;
    }
}
