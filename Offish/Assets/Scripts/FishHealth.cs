using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
public class FishHealth : MonoBehaviour
{
    // Post processing
    public PostProcessVolume _postProcessVolume;
    private ColorGrading _cg;
    public bool isHiding;
    private bool dying;

    private void Start()
    {
        _postProcessVolume.profile.TryGetSettings(out _cg);
    }

    public void Kill()
    {
        if (!dying)
            StartCoroutine(ExecuteDeath());
    }

    private IEnumerator ExecuteDeath()
    {
        dying = true;
        // IF YOU SET MAX SPEED TO ZERO THE CAMERA WILL FREAK OUT
        transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        transform.GetComponent<MoveFish>().acceleration = .001f;
        Vector4 originalGammaVal = _cg.gamma.value;
        _cg.gamma.Override(new Vector4(3f, 3f, 3f, 3f));
        Vector4 gammaVal = _cg.gamma.value;

        for (float i = 0; i < .12f; i += Time.deltaTime * .1f)
        {
            yield return new WaitForEndOfFrame();
            gammaVal = Vector4.Lerp(gammaVal, new Vector4(2f, 0f, 0f, -3f), i);
            _cg.gamma.Override(gammaVal);
            print(i);
        }

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        //_cg.gamma.Override(originalGammaVal);
    }

    public void ChangeTemperature(float newTemp)
    {
        //StartCoroutine(ExecuteChangeTemperature(newTemp));
        _cg.temperature.Override(-44f);
    }

    public IEnumerator ExecuteChangeTemperature(float newTemp)
    {
        float originalTemp = _cg.temperature.value;
        print(originalTemp);
        for (float i = 0; i < 1; i += Time.deltaTime * .1f)
        {
            yield return new WaitForEndOfFrame();
            _cg.temperature.Override(Mathf.Lerp(originalTemp, newTemp, i));
        }
    }
}
