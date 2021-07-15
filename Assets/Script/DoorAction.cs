using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            transform.GetComponent<Animator>().SetBool("isOpen", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            transform.GetComponent<Animator>().SetBool("isOpen", false);
        }
       
    }
}
