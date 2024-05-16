using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    public GameObject jellyfishBullets;
    public int numberOfProjectiles;
    public float bulletSpeed = 1;
    private bool canShoot = true;

    private void Start()
    {
        StartCoroutine(Cycle());
    }
    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            canShoot = false;

            float angleStep = 360f / numberOfProjectiles;
            float angle = 0f;

            // shoots bullets in a wide radius
            for (int i = 0; i < numberOfProjectiles; i++)
            {

                // Direction calculations
                float projectileDirXposition = 3f * Mathf.Cos(angle * Mathf.Deg2Rad);
                float projectileDirYposition = 3f * Mathf.Sin(angle * Mathf.Deg2Rad);

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
            yield return new WaitForSeconds(4f);
            canShoot = true;
        }
    }
}
