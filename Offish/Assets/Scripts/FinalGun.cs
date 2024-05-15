using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public float bulletSpeed;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = bulletSpawnPoint.position.z - Camera.main.transform.position.z;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 direction = (mousePosition - bullet.transform.position).normalized;
            bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
            bullet.transform.forward = direction;
        }
    }
}
