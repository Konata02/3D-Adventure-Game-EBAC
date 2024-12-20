using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVerification : MonoBehaviour
{
    public AudioSource sound;

    void Start()
    {
        if (sound == null)
        {
            sound = GetComponent<AudioSource>(); // Tenta pegar a AudioSource do próprio objeto
        }
    }
}
