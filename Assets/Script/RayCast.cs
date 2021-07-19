using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;

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

    public GameObject tv_display;
    public Transform showtv;

    public Transform bath;
    public Transform frontbath;
    public GameObject showerwater;

    void Raycasting()
    {
        //public GameObject gauge;
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward * 10000);
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
            else if(hit.transform.tag == "TV")
            {
                gauge.fillAmount = timegone / 3;
                timegone = Time.deltaTime + timegone;
                if (timegone >= 3)
                {
                    StartCoroutine(ShowTV());
                    tv_display.SetActive(true);
                    timegone = 3;

                }
            }
            else if(hit.transform.tag == "Bath")
            {
                gauge.fillAmount = timegone / 3;
                timegone = Time.deltaTime + timegone;
                if (timegone >= 3)
                {
                    StartCoroutine(Bath());
                    timegone = 3;

                }
            }
            else if(hit.transform.tag == "Water")
            {
                gauge.fillAmount = timegone / 3;
                timegone = Time.deltaTime + timegone;
                if (timegone >= 3)
                {
                    showerwater.SetActive(true);
                    timegone = 3;

                }
            }
            else if(hit.transform.tag == "FrontBath")
            {
                gauge.fillAmount = timegone / 3;
                timegone = Time.deltaTime + timegone;
                if (timegone >= 3)
                {
                    StartCoroutine(FrontBath());
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
            head.transform.position = Vector3.MoveTowards(head.transform.position, dooropen.position, Time.deltaTime * 0.01f);
            yield return null;
        }
    }
    IEnumerator ShowTV()
    {
        while (head.transform.position != showtv.position)
        {
            head.transform.position = Vector3.MoveTowards(head.transform.position, showtv.position, Time.deltaTime * 0.01f);
            yield return null;
        }
    }
    IEnumerator Bath()
    {
        while (head.transform.position != bath.position)
        {
            head.transform.position = Vector3.MoveTowards(head.transform.position, bath.position, Time.deltaTime * 0.01f);
            yield return null;
        }
    }
    IEnumerator FrontBath()
    {
        while (head.transform.position != frontbath.position)
        {
            head.transform.position = Vector3.MoveTowards(head.transform.position, frontbath.position, Time.deltaTime * 0.01f);
            yield return null;
        }
    }

}
