using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1To2 : MonoBehaviour
{
    public Transform diver;
    public Transform diverInstanceEmpty;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Transform player = collision.transform;

            player.GetComponent<MoveFish>().enabled = false;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameObject diverInstance = Instantiate(diver, diverInstanceEmpty.position, Quaternion.identity).gameObject;
            diverInstance.GetComponent<DiverBehavior>().damage = 100;
            diverInstance.GetComponent<DiverBehavior>().dashDistance = 30f;
            diverInstance.GetComponent<DiverBehavior>().isAnimatedDiver = true;
        }
    }

    public void ExecuteScene1End()
    {
        StartCoroutine(ActuallyExecute());
    }

    private IEnumerator ActuallyExecute()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Scene1-Scene2");
    }
}
