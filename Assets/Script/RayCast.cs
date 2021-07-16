using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Raycasting();
    }

    public Image gauge;
    float timegone;

    void Raycasting()
    {
        //public GameObject gauge;
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward * 1000);
        if (Physics.Raycast(transform.position, forward, out hit))
        {
            if (hit.collider.tag == "Door")
            {
                timegone = Time.deltaTime + timegone;
                gauge.fillAmount = timegone / 3;
                if (timegone >= 3)
                {
                    timegone = 3;
                }
            }
            else
            {
                gauge.fillAmount = 0;
                timegone = 0;
            }
        }
        Debug.DrawRay(transform.position, forward, Color.blue);
    }
}
