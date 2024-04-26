using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Cyborg : MonoBehaviour
{
    public Transform player;
    public PostProcessVolume _postProcessVolume;
    private ColorGrading _cg;

    // Start is called before the first frame update
    void OnEnable()
    {
        _postProcessVolume.profile.TryGetSettings(out _cg);
        StartCoroutine(ChangeTemperature());
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
