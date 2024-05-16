using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Cyborg : MonoBehaviour
{
    public Transform player;
    public GameObject cyborgBullet;
    public float cyborgBulletVelocity = 1f;
    public PostProcessVolume _postProcessVolume;
    public List<Transform> evilSquids = new List<Transform>();
    public List<Transform> jellyfish = new List<Transform>();

    private float shootRate = 3f;
    private ColorGrading _cg;
    private int phase = 0;

    //PHASE 1
    private int downedSquid = 0;

    //PHASE 2
    private bool startedPhase = false;

    // Start is called before the first frame update
    void OnEnable()
    {
        _postProcessVolume.profile.TryGetSettings(out _cg);
        Camera.main.GetComponent<FishCamera>().zOriginal = -350.7f;
        StartCoroutine(ChangeTemperature());

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

    // PHASE 1
    public void KilledSquid()
    {
        downedSquid++;

        if (downedSquid == 4)
        {
            phase++;
            StartPhase1();

            //making them slowly sink down
            foreach (Transform t in evilSquids)
            {
                t.GetComponent<Rigidbody>().velocity = Vector3.down * 2f;
            }
        }
    }

    //SPAWN IN THA JELLYFISH
    private void StartPhase1()
    {
        foreach (Transform t in jellyfish)
        {
            t.gameObject.SetActive(true);
        }
    }
}
