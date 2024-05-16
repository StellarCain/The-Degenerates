using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishHealth : MonoBehaviour
{
    private int health = 100;
    private Material jellyfishMaterial;
    public GameObject jellyfishTop;
    private Cyborg cyborg;

    // Start is called before the first frame update
    void Start()
    {
        jellyfishMaterial = jellyfishTop.GetComponent<MeshRenderer>().material;
        cyborg = FindObjectOfType<Cyborg>();
    }

    public void Damage(int damage)
    {
        health -= damage;
        jellyfishMaterial.SetVector("_EmissionColor", jellyfishMaterial.GetColor("_EmissionColor") * (health / 100f));

        if (health == 40)
        {
            cyborg.KilledEnemy();
            transform.GetComponent<Jellyfish>().enabled = false;
            transform.GetComponent<Rigidbody>().useGravity = true;
            enabled = false;
        }
    }
}
