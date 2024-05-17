using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    public ParticleSystem explosion;
    public Transform player;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(Explode());
        }
    }
    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(1);
        explosion.Emit(100);
        player.GetComponent<FishHealth>().Kill();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Scene2-Boss Battle");
    }
}