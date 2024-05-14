using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Cyborg : MonoBehaviour
{
    public Transform player;
    public UnityEngine.GameObject cyborgBullet;
    public float cyborgBulletVelocity = 1f;
    public PostProcessVolume _postProcessVolume;
    public List<Transform> evilSquids = new List<Transform>();

    private float shootRate = 3f;
    private ColorGrading _cg;

    // Start is called before the first frame update
    void OnEnable()
    {
        _postProcessVolume.profile.TryGetSettings(out _cg);
        Camera.main.GetComponent<FishCamera>().zOriginal = -350.7f;
        StartCoroutine(ChangeTemperature());
        StartCoroutine(ShootRoutine());

        foreach (Transform t in evilSquids)
        {
            t.gameObject.SetActive(true);
        }
    }

    private IEnumerator ChangeTemperature()
    {
        float originalTemp = _cg.temperature.value;

        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            print("original");
            yield return new WaitForEndOfFrame();
            _cg.temperature.Override(Mathf.Lerp(originalTemp, -34f, i));
        }
    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootRate);
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        UnityEngine.GameObject bullet = Instantiate(cyborgBullet, transform.position,
            Quaternion.LookRotation(transform.position - (player.position + player.GetComponent<Rigidbody>().velocity / 2)));
        bullet.GetComponent<Rigidbody>().velocity = -bullet.transform.forward * cyborgBulletVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =
            Vector3.Lerp(transform.position,
            new Vector3(player.position.x, player.position.y,
            transform.position.z), 2f * Time.deltaTime);

        // casting a ray towards the player
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(player.position.x, player.position.y, transform.position.z), -Vector3.forward, out hit, 1000))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Vector3 direction = player.position - transform.position;
                Quaternion lookRotaton = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotaton, 10f * Time.deltaTime);
                //damageTimer += Time.deltaTime;
            }
        }
    }
}
