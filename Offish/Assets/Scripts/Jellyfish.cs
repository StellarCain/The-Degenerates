using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    public GameObject jellyfishBullets;
    public int numberOfProjectiles;
    public bool randomizeNumber = false;
    public float rate = 4f;
    public float bulletSpeed = 1;
    private bool canShoot = true;

    private int trueNumberOfProjectiles;

    private void Start()
    {
        trueNumberOfProjectiles = numberOfProjectiles;
        StartCoroutine(Cycle());
    }
    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            canShoot = false;

            if (randomizeNumber)
            {
                trueNumberOfProjectiles = numberOfProjectiles + Random.Range(-20, 20);
            }

            float angleStep = 360f / trueNumberOfProjectiles;
            float angle = 0f;

            // shoots bullets in a wide radius
            for (int i = 0; i < trueNumberOfProjectiles; i++)
            {

                // Direction calculations
                float projectileDirXposition = 3f * Mathf.Cos((angle + Time.deltaTime * 100f) * Mathf.Deg2Rad);
                float projectileDirYposition = 3f * Mathf.Sin((angle + Time.deltaTime * 100f) * Mathf.Deg2Rad);

                angle += angleStep;
                GameObject bulletInstance = Instantiate(jellyfishBullets, transform.position, Quaternion.identity);

                Vector3 direction = (transform.position - new Vector3(transform.position.x + projectileDirXposition, transform.position.y + projectileDirYposition, transform.position.z)).normalized;
                bulletInstance.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
                bulletInstance.transform.forward = direction;

                //bulletInstance.transform.position = new Vector3(projectileDirXposition, projectileDirYposition, transform.position.z);
            }
        }
    }

    private IEnumerator Cycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(rate);
            canShoot = true;
        }
    }
}
