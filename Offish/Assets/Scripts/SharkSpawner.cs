using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSpawner : MonoBehaviour
{
    [SerializeField]
    public float frames;
    public float detectionRange = 100;
    public float targetStrength = 5f;
    public float delay = 0f;
    public float sharkSpeed = 150f;
    public UnityEngine.GameObject shark;
    public bool chase = false;
    private Transform player;
    private bool started = false;

    // Start is called before the first frame update
    private void Start()
    {
        player = UnityEngine.GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, new Vector3(transform.position.x, transform.position.y, player.position.z)) < detectionRange && !started)
        {
            StartCoroutine(Behavior());
        }
    }


    private IEnumerator Behavior()
    {
        started = true;
        yield return new WaitForSeconds(delay);
        for (float i = 0; i <= 1; i += (1 / frames))
        {
            yield return new WaitForEndOfFrame();
            transform.GetComponent<VLight>().lightMultiplier = Mathf.Lerp(transform.GetComponent<VLight>().lightMultiplier, targetStrength, i * Time.deltaTime);

            if (Vector3.Distance(player.position, new Vector3(transform.position.x, transform.position.y, player.position.z)) > detectionRange * 1.5f)
            {
                UnityEngine.GameObject sharkInstance = Instantiate(shark, new Vector3(transform.position.x, transform.position.y, player.transform.position.z + 20), Quaternion.Euler(0, -90, 0), transform);
                sharkInstance.GetComponent<SharkBehavior>().speed = sharkSpeed;
                yield break;
            }
        }

        UnityEngine.GameObject sharke = Instantiate(shark, new Vector3(transform.position.x, transform.position.y, player.transform.position.z), Quaternion.Euler(0, -90, 0), transform);
        sharke.GetComponent<SharkBehavior>().speed = sharkSpeed;
        sharke.GetComponent<SharkBehavior>().chaseShark = chase;
    }

    public IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(2f);

        for (float i = 0; i <= 1; i += .01f)
        {
            yield return new WaitForEndOfFrame();
            transform.GetComponent<VLight>().lightMultiplier = Mathf.Lerp(targetStrength, 0, i);
        }

        yield return new WaitForSeconds(2f);
        Destroy(transform.gameObject);
    }
}
