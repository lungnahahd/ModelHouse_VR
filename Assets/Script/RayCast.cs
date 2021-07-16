﻿using System.Collections;
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
    public Transform dooropen;
    public GameObject head;

    void Raycasting()
    {
        //public GameObject gauge;
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward * 1000);
        if (Physics.Raycast(transform.position, forward, out hit))
        {
            if (hit.transform.tag == "Door")
            {
                gauge.fillAmount = timegone / 3;
                timegone = Time.deltaTime + timegone;
                if (timegone >= 3)
                {
                    StartCoroutine(InHome());
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

    IEnumerator InHome()
    {
        while (head.transform.position != dooropen.position)
        {
            head.transform.position = Vector3.MoveTowards(head.transform.position, dooropen.position, Time.deltaTime);
            yield return null;
        }
    }
}
