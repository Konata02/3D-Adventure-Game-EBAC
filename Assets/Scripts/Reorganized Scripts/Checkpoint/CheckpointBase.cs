using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int key = 01;
    private bool checkPointActived = false;
    private string checkpointKey = "CheckpointKey";
     
    void OnTriggerEnter(Collider other)
    {
        if (!checkPointActived && other.CompareTag("Player"))
        {
           CheckCheckpoint();
           SaveCheckpoint();
           
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void CheckCheckpoint(){

        TurnOnIt();
    }

    public void TurnOnIt(){
       meshRenderer.material.SetColor("_Color",Color.white);
    }

    private void SaveCheckpoint(){
        /*if (PlayerPrefs.GetInt(checkpointKey, 0)> key)  PlayerPrefs.SetInt(checkpointKey, key);
        */
        CheckpointManager.Instance.SaveCheckpoint(key);
        checkPointActived = true;
    }

}
