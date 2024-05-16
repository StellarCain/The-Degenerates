using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidHealth : MonoBehaviour
{
    public GameObject squidEye1;
    public GameObject squidEye2;
    private float health = 100;
    private Material squidMaterial1;
    private Material squidMaterial2;
    private Cyborg cyborg;

    // Start is called before the first frame update
    void Start()
    {
        cyborg = FindObjectOfType<Cyborg>();
        squidMaterial1 = squidEye1.GetComponent<MeshRenderer>().material;
        squidMaterial2 = squidEye2.GetComponent<MeshRenderer>().material;
    }

    public void Damage(int damage)
    {
        health -= damage;
        squidMaterial1.SetVector("_EmissionColor", squidMaterial1.GetColor("_EmissionColor") * (health / 100));
        squidMaterial2.SetVector("_EmissionColor", squidMaterial2.GetColor("_EmissionColor") * (health / 100));

        if (health == 0)
        {
            cyborg.KilledEnemy();
            print("destroying");
            transform.GetComponent<EvilSquid>().enabled = false;
            transform.GetComponent<Rigidbody>().useGravity = true;
            enabled = false;
            Destroy(gameObject);
        }
    }
}
