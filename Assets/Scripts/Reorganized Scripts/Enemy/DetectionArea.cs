using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionArea : MonoBehaviour
{

    public bool playerInArea = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            playerInArea =true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInArea = false;
        }
    }

}
