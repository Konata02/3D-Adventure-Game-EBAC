using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorreçãoDeBugInexplicável : MonoBehaviour
{
    // Start is called before the first frame update
    
    public List<GameObject> cloths;
    void Start()
    {
        for (int i = 0; i < cloths.Count; i++)
        {
            cloths[i].SetActive(false);
        }

         for (int i = 0; i < cloths.Count; i++)
        {
            cloths[i].SetActive(true);
        }

    }

}
