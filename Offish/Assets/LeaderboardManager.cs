using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField]
    private Transform leaderboard;

    // Start is called before the first frame update
    public void EnableLeaderboard()
    {
        leaderboard.gameObject.SetActive(true);
    }

    public void DisableLeaderboard()
    {
        leaderboard.gameObject.SetActive(false);
    }
}
