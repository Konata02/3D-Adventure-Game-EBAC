using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        SaveManager.Instance.Fileloaded += OnLoad;
    }

    public void OnLoad(SaveSetup setup)
    {

    }

    private void OnDestroy()
    {
        
    }

}
