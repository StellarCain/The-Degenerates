using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFish : MonoBehaviour
{
    //speed at which we are to be traveling
    public float spd = 5f;
    //place where we are to be going
    private Vector3 plc;
    // Start is called before the first frame update
    void Start()
    {
        //we start where we are
        plc = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseClickPosition = Input.mousePosition;
            mouseClickPosition.z = 10f;

            plc = Camera.main.ScreenToWorldPoint(mouseClickPosition);
            plc.z = transform.position.z;

            print("pos: " + plc);

            Vector3 direction = transform.position - plc;
            Quaternion rot = Quaternion.LookRotation(direction);
            transform.rotation = rot;
        }

        // we ball
        //transform.position = Vector3.MoveTowards(transform.position, plc, spd * Time.deltaTime);
    }
}