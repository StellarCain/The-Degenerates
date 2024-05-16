using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Cyborg : MonoBehaviour
{
    public Transform player;
    public GameObject cyborgBullet;
    public float cyborgBulletVelocity = 1f;
    public PostProcessVolume _postProcessVolume;
    public List<Transform> evilSquids = new List<Transform>();
    public List<Transform> jellyfish = new List<Transform>();
    public List<Transform> finalEnemies = new List<Transform>();
    public Slider bossHealthSlider;
    private float bossHealth = 100;

    private float shootRate = 3f;
    private ColorGrading _cg;
    private int phase = 0;

    //ALL PHASES 0, 1 ,2
    private int downedEnemies = 0;

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
            yield return new WaitForEndOfFrame();
            _cg.temperature.Override(Mathf.Lerp(originalTemp, -34f, i));
        }
    }

    // PHASE 1
    public void KilledEnemy()
    {
        downedEnemies++;

        bossHealth -= 100f / 15f;

        if (downedEnemies == 4)
        {
            phase++;
            StartPhase1();
        }
        else if (downedEnemies == 7)
        {
            phase++;
            StartPhase2();

            foreach (Transform t in jellyfish)
            {
                Destroy(t.gameObject, 2f);
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

    private void StartPhase2()
    {
        foreach (Transform t in finalEnemies)
        {
            t.gameObject.SetActive(true);
        }
    }
}

