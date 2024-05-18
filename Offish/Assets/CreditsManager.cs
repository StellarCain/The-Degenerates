using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    [SerializeField]
    private Transform credits;

    // Start is called before the first frame update
    public void EnableCredits()
    {
        credits.gameObject.SetActive(true);
    }

    public void DisableCredits()
    {
        credits.gameObject.SetActive(false);
    }
}
