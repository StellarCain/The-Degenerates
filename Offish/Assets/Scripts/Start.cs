using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public void PlayGame()
    {
        LeaderboardInteractor.StartTime();

        SceneManager.LoadScene("Menu-Scene1");
    }
}
