using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multishotcode : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform bulletSpawnPoint;
    public Transform bulletSpawnPointA;
    public Transform bulletSpawnPointB;
    public Transform bulletSpawnPointC;
    public UnityEngine.GameObject bulletPrefab;
    public float bulletSpeed = 400;
    public ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            /*
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = bulletSpawnPoint.position.z - Camera.main.transform.position.z;
            Vector3 direction = (mousePosition - bullet.transform.position).normalized;

            */
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * bulletSpeed;

            muzzleFlash.Emit(30);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            var bullet = Instantiate(bulletPrefab, bulletSpawnPointA.position, bulletSpawnPointA.rotation);
            /*
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = bulletSpawnPointA.position.z - Camera.main.transform.position.z;
            Vector3 direction = (mousePosition - bullet.transform.position).normalized;
            */
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * bulletSpeed;

            muzzleFlash.Emit(30);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPointB.position, bulletSpawnPointB.rotation);
            /*
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = bulletSpawnPointB.position.z - Camera.main.transform.position.z;
            Vector3 direction = (mousePosition - bullet.transform.position).normalized;
            */
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * bulletSpeed;

            muzzleFlash.Emit(30);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPointC.position, bulletSpawnPointC.rotation);
            /*
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = bulletSpawnPointC.position.z - Camera.main.transform.position.z;
            Vector3 direction = (mousePosition - bullet.transform.position).normalized;
            */

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * bulletSpeed;

            muzzleFlash.Emit(30);
        }
    }


}
