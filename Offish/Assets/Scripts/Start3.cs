using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start3 : MonoBehaviour
{
    public string sceneName = "Scene1";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OpenScene());
    }

    private IEnumerator OpenScene()
    {
        yield return new WaitForSeconds(38f);
        SceneManager.LoadScene(sceneName);
    }
}
