using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField]
    private Transform leaderboard;
    [SerializeField]
    private List<TMPro.TMP_Text> slots;
    [SerializeField]
    private TimeManager timeManager;

    // Start is called before the first frame update
    public void EnableLeaderboard()
    {
        leaderboard.gameObject.SetActive(true);

        List<int> scores = timeManager.GetHighScores();
        int i = 0;
        foreach (int score in scores)
        {
            slots[i].text = "" + score;
            i++;
        }
    }

    public void DisableLeaderboard()
    {
        leaderboard.gameObject.SetActive(false);
    }
}
