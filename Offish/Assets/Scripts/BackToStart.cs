using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStart : MonoBehaviour
{   
    public string sceneName = "Scene1";
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(GoBack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator GoBack()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(sceneName);
    }
}
