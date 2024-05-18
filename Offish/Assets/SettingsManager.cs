using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private Transform settings;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EnableSettings();
        }
    }

    // Start is called before the first frame update
    public void EnableSettings()
    {
        settings.gameObject.SetActive(true);
    }

    public void DisableSettings()
    {
        settings.gameObject.SetActive(false);
    }
}
