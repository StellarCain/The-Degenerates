using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Cyborg : MonoBehaviour
{
    public Transform player;
    public AudioSource bossMusic;
    public GameObject cyborgBullet;
    public float cyborgBulletVelocity = 1f;
    public PostProcessVolume _postProcessVolume;
    public List<Transform> evilSquid = new List<Transform>();
    public List<Transform> jellyfish = new List<Transform>();
    public List<Transform> combinedEnemies = new List<Transform>();
    public Transform superJelly;
    public List<Transform> finalEnemies = new List<Transform>();
    public List<Transform> finalFinalEnemies = new List<Transform>();
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

        bossHealthSlider.transform.gameObject.SetActive(true);

        print("activating boss");

        foreach (Transform t in evilSquid)
        {
            t.gameObject.SetActive(true);
        }

        player.GetComponent<FinalGun>().enabled = true;
        bossMusic.Play();

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

        bossHealth -= 100f / 33f;
        bossHealthSlider.value = bossHealth / 100f;

        if (downedEnemies == 4)
        {
            phase++;
            StartCoroutine(StartPhase1());
        }
        else if (downedEnemies == 7)
        {
            phase++;
            StartCoroutine(StartPhase2());
        }
        else if (downedEnemies == 13)
        {
            phase++;
            StartCoroutine(StartPhase3());
        }
        else if (downedEnemies == 14)
        {
            phase++;
            StartCoroutine(StartPhase4());
        }
        else if (downedEnemies == 23)
        {
            phase++;
            StartCoroutine(StartPhase5());
        }
    }

    //SPAWN IN THA JELLYFISH
    private IEnumerator StartPhase1()
    {
        yield return new WaitForSeconds(2);
        foreach (Transform t in jellyfish)
        {
            t.gameObject.SetActive(true);
        }
    }

    private IEnumerator StartPhase2()
    {
        yield return new WaitForSeconds(2);
        foreach (Transform t in combinedEnemies)
        {
            t.gameObject.SetActive(true);
        }
    }

    private IEnumerator StartPhase3()
    {
        yield return new WaitForSeconds(2);
        superJelly.gameObject.SetActive(true);
    }

    private IEnumerator StartPhase4()
    {
        yield return new WaitForSeconds(2);
        foreach (Transform t in finalEnemies)
        {
            t.gameObject.SetActive(true);
        }
    }

    private IEnumerator StartPhase5()
    {
        yield return new WaitForSeconds(2);
        foreach (Transform t in finalFinalEnemies)
        {
            t.gameObject.SetActive(true);
        }
    }
}

