using UnityEngine;
using System.Collections.Generic;

public class TimeManager : MonoBehaviour
{
    private const int MaxScores = 10;
    private List<int> highScores;

    void Start()
    {
        LoadScores();
    }

    public void AddNewScore(int seconds)
    {
        highScores.Add(seconds);
        highScores.Sort((a, b) => b.CompareTo(a)); 
        if (highScores.Count > MaxScores)
        {
            highScores.RemoveAt(MaxScores);
        }
        SaveScores();
    }

    private void SaveScores()
    {
        for (int i = 0; i < MaxScores; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i, i < highScores.Count ? highScores[i] : 0);
        }
        PlayerPrefs.Save();
    }

    private void LoadScores()
    {
        highScores = new List<int>();
        for (int i = 0; i < MaxScores; i++)
        {
            highScores.Add(PlayerPrefs.GetInt("HighScore" + i, 0));
        }
    }

    public List<int> GetHighScores()
    {
        return new List<int>(highScores); // Return a copy to avoid external modifications
    }
}
