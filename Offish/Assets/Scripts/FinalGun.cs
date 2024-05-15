using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGun : MonoBehaviour
{
    public Transform bulletSpawnPosition;
    public float bulletSpeed;
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 mouseClickPosition = Input.mousePosition;
            mouseClickPosition.z = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);

            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseClickPosition);
            mouseWorldPosition.z = transform.position.z;

            GameObject bulletInstance = Instantiate(bullet, bulletSpawnPosition.position, Quaternion.Euler(transform.position - mouseWorldPosition));
            bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * 200, ForceMode.Force);
        }
    }
}
