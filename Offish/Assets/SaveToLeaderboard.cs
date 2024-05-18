using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveToLeaderboard : MonoBehaviour
{
    public TimeManager timeManager;

    // Start is called before the first frame update
    public void Save()
    {
        timeManager.AddNewScore(Mathf.RoundToInt(LeaderboardInteractor.GetTime()));
        SceneManager.LoadScene("Credits");
    }
}
