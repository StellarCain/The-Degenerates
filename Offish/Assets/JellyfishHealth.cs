using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishHealth : MonoBehaviour
{
    private int health = 100;
    private Material jellyfishMaterial;

    // Start is called before the first frame update
    void Start()
    {
        jellyfishMaterial = transform.GetComponent<MeshRenderer>().material;
    }

    public void Damage(int damage)
    {
        health -= damage;
        jellyfishMaterial.SetVector("_EmissionColor", jellyfishMaterial.GetColor("_EmissionColor") * (health / 100));
    }
}
