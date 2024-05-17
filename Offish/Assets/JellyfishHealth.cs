using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishHealth : MonoBehaviour
{
    public float maxHealth = 100;
    private float health = 100;
    private Material jellyfishMaterial;
    public GameObject jellyfishTop;
    private Cyborg cyborg;

    // Start is called before the first frame update
    void Start()
    {
        jellyfishMaterial = jellyfishTop.GetComponent<MeshRenderer>().material;
        cyborg = FindObjectOfType<Cyborg>();

        health = maxHealth;
    }

    public void Damage(int damage)
    {
        health -= damage;
        jellyfishMaterial.SetVector("_EmissionColor", jellyfishMaterial.GetColor("_EmissionColor") * (health / maxHealth));

        if (health == 40)
        {
            Destroy(gameObject, 1f);
            cyborg.KilledEnemy();
            transform.GetComponent<Jellyfish>().enabled = false;
            transform.GetComponent<Rigidbody>().useGravity = true;
            enabled = false;
        }
    }
}
