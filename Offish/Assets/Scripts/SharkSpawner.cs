using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSpawner : MonoBehaviour
{
    [SerializeField]
    public float frames;
    public float detectionRange = 100;
    public Vector3 targetSize;
    public GameObject shark;
    private Transform player;
    private bool started = false;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < detectionRange && !started)
        {
            StartCoroutine(Behavior());
        }
    }


    private IEnumerator Behavior()
    {
        started = true;
        for (float i = 0; i <= 1; i += (1 / frames))
        {
            yield return new WaitForEndOfFrame();
            transform.localScale = Vector3.Lerp(transform.localScale, targetSize, i * Time.deltaTime);
        }

        Instantiate(shark, transform.position, Quaternion.identity);
        Destroy(transform.gameObject);
    }
}
